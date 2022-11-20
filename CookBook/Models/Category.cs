namespace CookBook.Models
{
#nullable enable
    using Data.SeedWork;

    public class Category
        : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public Category(string name)
        {
            this.Name = name;
            Recipes = null!;
        }

        protected Category()
        {
            Name = null!;
            Recipes = null!;
        }
    }
}
