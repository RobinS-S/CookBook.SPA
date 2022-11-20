using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos
{
    public class RecipeIngredientAmountDto
    {
        public long Id { get; set; }

        public long IngredientId { get; set; }

        [Required]
        [StringLength(64)]
        public string Amount { get; set; }

        protected RecipeIngredientAmountDto()
        {
            Amount = null!;
        }
    }
}
