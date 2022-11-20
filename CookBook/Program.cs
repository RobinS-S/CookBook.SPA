using CookBook.Data;
using CookBook.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

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
                app.UseSwaggerUI();
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