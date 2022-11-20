using CookBook.Data.SeedWork;

namespace CookBook.Models
{
    public class RecipeIngredientAmount : Entity
    {
        public Ingredient Ingredient { get; set; }
        public string Amount { get; set; }

        public RecipeIngredientAmount(Ingredient ingredient, string amount)
        {
            Ingredient = ingredient;
            Amount = amount;
        }

        protected RecipeIngredientAmount()
        {
            Ingredient = null!;
            Amount = null!;
        }
    }
}