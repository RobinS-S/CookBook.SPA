using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos
{
    public class RecipeDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Required]
        [StringLength(128)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        public IList<long> CategoryIds { get; set; }

        public IList<RecipeIngredientAmountDto> IngredientAmounts { get; set; }

        protected RecipeDto()
        {
            Title = null!;
            Description = null!;
            ShortDescription = null!;
            CategoryIds = null!;
            IngredientAmounts = null!;
        }
    }
}
