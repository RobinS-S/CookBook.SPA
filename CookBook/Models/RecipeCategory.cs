using CookBook.Data.SeedWork;

namespace CookBook.Models
{
    public class RecipeCategory : Entity
    {
        public Recipe Recipe { get; set; }
        public Category Category { get; set; }

        public RecipeCategory(Recipe recipe, Category category)
        {
            Recipe = recipe;
            Category = category;
        }

        protected RecipeCategory()
        {
            Recipe = null!;
            Category = null!;
        }
    }
}
