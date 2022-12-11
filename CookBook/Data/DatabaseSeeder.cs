using CookBook.Auth;
using CookBook.Models;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Data;

public class DatabaseSeeder
{
    public static async Task SeedDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var adminRoleName = Roles.Admin;

        var roleExist = await roleManager.RoleExistsAsync(adminRoleName);
        if (!roleExist) await roleManager.CreateAsync(new IdentityRole(adminRoleName));

        var userName = configuration["AdminUserEmail"];
        var userPassword = configuration["AdminUserPassword"];
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userPassword))
            throw new Exception(
                "You need to provide a default user account which will be created with the Admin role, keys: AppSettings:AdminUserEmail and AppSettings:AdminUserPassword");

        var defaultUser = new ApplicationUser
        {
            UserName = userName,
            Email = userName
        };

        var user = await userManager.FindByEmailAsync(userName);

        if (user == null)
        {
            var createPowerUser = await userManager.CreateAsync(defaultUser, userPassword);
            if (createPowerUser.Succeeded) await userManager.AddToRoleAsync(defaultUser, Roles.Admin);
        }
        else
        {
            var isAdmin = await userManager.IsInRoleAsync(user, Roles.Admin);
            if (!isAdmin) await userManager.AddToRoleAsync(user, Roles.Admin);
        }
    }
}