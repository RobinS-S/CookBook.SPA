using CookBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Data.Configurations
{
    public class RecipeEntityTypeConfiguration
        : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasMany(r => r.Categories)
                .WithMany(c => c.Recipes)
                .UsingEntity<RecipeCategory>(l =>
                    l.HasOne(rc => rc.Category)
                    .WithMany()
                    .HasForeignKey("category_id"),
                    r => r.HasOne(rc => rc.Recipe)
                    .WithMany()
                    .HasForeignKey("recipe_id")
                );

            builder.OwnsMany(r => r.IngredientAmounts, ria =>
            {
                ria.WithOwner();
                ria.HasOne(ria => ria.Ingredient)
                    .WithMany();
                ria.Property(p => p.Amount)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsRequired();
            });

            builder.Property(c => c.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.ShortDescription)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(512)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
