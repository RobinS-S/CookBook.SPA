using CookBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Data.Configurations
{
    public class IngredientEntityTypeConfiguration
        : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
