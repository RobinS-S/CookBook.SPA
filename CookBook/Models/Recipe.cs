using CookBook.Data.SeedWork;

namespace CookBook.Models;

public class Recipe
    : Entity, IAggregateRoot
{
    public Recipe(string title, IEnumerable<IngredientEntry> ingredients, IEnumerable<PreparationStep> preparation)
    {
        Title = title;
        IngredientEntries = new HashSet<IngredientEntry>(ingredients);
        Preparation = new HashSet<PreparationStep>(preparation);
        Categories = null!;
        RecipeCategories = null!;
    }

    private Recipe()
    {
        Title = null!;
        IngredientEntries = null!;
        Preparation = null!;
        Categories = null!;
        RecipeCategories = null!;
    }

    public string Title { get; set; }

    public string? Description { get; set; }

    public int SuitableFor { get; set; }

    public IEnumerable<IngredientEntry> IngredientEntries { get; set; }

    public IEnumerable<PreparationStep> Preparation { get; set; }

    public IEnumerable<Category> Categories { get; set; }

    public IEnumerable<RecipeCategory> RecipeCategories { get; set; }
}