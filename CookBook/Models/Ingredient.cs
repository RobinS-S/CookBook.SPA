namespace CookBook.Models
{
#nullable enable
    using Data.SeedWork;

    public class Ingredient
        : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public Ingredient(string name)
        {
            this.Name = name;
        }

        protected Ingredient()
        {
            this.Name = null!;
        }
    }
}
