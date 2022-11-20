using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos
{
    public class CategoryDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        protected CategoryDto()
        {
            Name = null!;
        }
    }
}
