using CookBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Data.Configurations;

public class RecipeEntityTypeConfiguration
    : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasMany(r => r.Categories)
            .WithMany(c => c.Recipes)
            .UsingEntity<RecipeCategory>(b => b
                    .HasOne(rc => rc.Category)
                    .WithMany(c => c.RecipeCategories),
                b => b
                    .HasOne(rc => rc.Recipe)
                    .WithMany(r => r.RecipeCategories),
                b => { b.ToTable("recipe_category"); });

        builder.OwnsMany(r => r.IngredientEntries, ri =>
        {
            ri.WithOwner();

            ri.Property(c => c.Quantity)
                .IsRequired();

            ri.Property(c => c.Product)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            ri.Property(c => c.Unit)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        builder.OwnsMany(r => r.Preparation, p =>
        {
            p.WithOwner();

            builder.Property(c => c.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(2048)
                .IsUnicode()
                .IsRequired();
        });

        builder.Property(c => c.Title)
            .HasMaxLength(64)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(512)
            .IsUnicode(false)
            .IsRequired();
    }
}