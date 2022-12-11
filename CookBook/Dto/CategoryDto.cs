using System.ComponentModel.DataAnnotations;

namespace CookBook.Dto;

public class CategoryDto
{
    protected CategoryDto()
    {
        Name = null!;
    }

    public long? Id { get; set; }

    [Required] [StringLength(64)] public string Name { get; set; }

    [StringLength(128)] public string? Description { get; set; }
}