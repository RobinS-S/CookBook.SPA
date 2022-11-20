using CookBook.Data;
using CookBook.Models;
using CookBook.Services;
using CookBook.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.OpenApi.Models;

namespace CookBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Database") ?? throw new InvalidOperationException("Connection string 'Database' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString, opt => opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, DbConstants.SchemaName));
                options.UseSnakeCaseNamingConvention();
            });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews().AddNewtonsoftJson();
            builder.Services.AddRazorPages();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CookBook API", Version = "v1" });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<ICategoryService, CategoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CookBook API");
                });
            };

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.MapControllers();

            app.MapFallbackToFile("index.html");

            /*
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Categories.Add(new Category("Italiaans"));
            context.Ingredients.Add(new Ingredient("Kaas"));
            context.SaveChanges();
            var category = context.Categories.FirstOrDefault();
            var ingredient = context.Ingredients.FirstOrDefault();
            context.Recipes.Add(new Recipe("Pasta", "Een hele lekkere pasta.", new List<Category>() { category }, new List<RecipeIngredientAmount>() { new RecipeIngredientAmount(ingredient, "een handvol") }, "goeie pasta"));
            context.SaveChanges();
            var recipe = context.Recipes.FirstOrDefault();
            Console.ReadLine();
            */

            app.Run();
        }
    }
}