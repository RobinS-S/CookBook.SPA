namespace CookBook.Models;

public class RecipeCategory
{
    public RecipeCategory(long categoryId, long recipeId)
    {
        CategoryId = categoryId;
        RecipeId = recipeId;
        Category = null!;
        Recipe = null!;
    }

    protected RecipeCategory()
    {
        Category = null!;
        Recipe = null!;
    }

    public Category Category { get; set; }
    public Recipe Recipe { get; set; }
    public long CategoryId { get; set; }
    public long RecipeId { get; set; }
}