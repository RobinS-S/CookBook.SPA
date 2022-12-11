using CookBook.Auth;
using CookBook.Data;
using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CookBook;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services
            .Configure<Config>(Configuration)
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
            .AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<Config>>().Value);

        var connectionString = Configuration.GetConnectionString("Database") ??
                               throw new InvalidOperationException("Connection string 'Database' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                opt => opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, DbConstants.SchemaName));
            options.UseSnakeCaseNamingConvention();
        });
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

        services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(o =>
            {
                if (!Environment.IsDevelopment()) o.Clients[0].RedirectUris.Add("/swagger/oauth2-redirect.html");
            });

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddControllersWithViews().AddNewtonsoftJson();
        services.AddRazorPages();

        services.AddSwaggerGen();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<CategoryService>();
        services.AddScoped<RecipeService>();
    }

    public async Task Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.UseMigrationsEndPoint();
        else
            app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();

        await DatabaseSeeder.SeedDatabase(app.Services, Configuration); // Ensure the roles and a default user exists

        app.MapControllerRoute(
            "default",
            "{controller}/{action=Index}/{id?}");
        app.MapRazorPages();
        app.MapControllers();

        app.MapFallbackToFile("index.html");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1.0");
                setup.OAuthClientId("CookBook");
                setup.OAuthAppName("CookBook API");
                setup.OAuthScopeSeparator(" ");
                setup.OAuthUsePkce();
            });
        }
    }
}