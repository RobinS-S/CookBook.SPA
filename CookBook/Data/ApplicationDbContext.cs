using CookBook.Models;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookBook.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Recipe> Recipes { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Set PGSQL default schema
        builder.HasDefaultSchema(DbConstants.SchemaName);

        // Apply EntityTypeConfigurations
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Modify IdentityDbContext to match PGSQL's naming conventions to avoid issues with querying
        builder.Entity<ApplicationUser>().ToTable("asp_net_users", DbConstants.SchemaName);
        builder.Entity<IdentityUserToken<string>>().ToTable("asp_net_user_tokens", DbConstants.SchemaName);
        builder.Entity<IdentityUserLogin<string>>().ToTable("asp_net_user_logins", DbConstants.SchemaName);
        builder.Entity<IdentityUserClaim<string>>().ToTable("asp_net_user_claims", DbConstants.SchemaName);
        builder.Entity<IdentityRole>().ToTable("asp_net_roles", DbConstants.SchemaName);
        builder.Entity<IdentityUserRole<string>>().ToTable("asp_net_user_roles", DbConstants.SchemaName);
        builder.Entity<IdentityRoleClaim<string>>().ToTable("asp_net_role_claims", DbConstants.SchemaName);
        builder.Entity<PersistedGrant>().ToTable("identity_persisted_grants", DbConstants.SchemaName);
        builder.Entity<DeviceFlowCodes>().ToTable("identity_device_flow_codes", DbConstants.SchemaName);
    }
}