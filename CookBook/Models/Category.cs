namespace CookBook.Models
{
#nullable enable
    using Data.SeedWork;

    public class Category
        : Entity, IAggregateRoot
    {
        private IEnumerable<Recipe> recipeIds;

        public string Name { get; set; }

        public Category(string name)
        {
            this.Name = name;
            recipeIds = null!;
        }

        protected Category()
        {
            Name = null!;
            recipeIds = null!;
        }
    }
}
