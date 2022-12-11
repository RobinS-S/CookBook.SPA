using CookBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Data.Configurations;

public class CategoryEntityTypeConfiguration
    : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(64)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(128)
            .IsUnicode(false);
    }
}