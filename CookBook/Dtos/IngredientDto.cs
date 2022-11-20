using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos
{
    public class IngredientDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        protected IngredientDto()
        {
            Name = null!;
        }
    }
}
