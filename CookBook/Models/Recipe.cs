namespace CookBook.Models
{
#nullable enable
    using Data.SeedWork;

    public class Recipe
        : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<RecipeIngredientAmount> IngredientAmounts { get; set; }

        public Recipe(string title, string description, ICollection<Category> categories, ICollection<RecipeIngredientAmount> ingredientAmounts, string shortDescription = null!)
        {
            this.Title = title;
            this.Description = description;
            this.ShortDescription = shortDescription;
            this.Categories = categories;
            this.IngredientAmounts = ingredientAmounts;
        }

        protected Recipe()
        {
            this.Title = null!;
            this.Description = null!;
            this.ShortDescription = null!;
            this.Categories = null!;
            this.IngredientAmounts = null!;
        }
    }
}
