using CookBook.Data.SeedWork;

namespace CookBook.Models;

public class Category
    : Entity, IAggregateRoot
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();

    public ICollection<RecipeCategory> RecipeCategories { get; set; } = new HashSet<RecipeCategory>();
}