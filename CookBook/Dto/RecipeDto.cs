using System.ComponentModel.DataAnnotations;

namespace CookBook.Dto;

public class RecipeDto
{
    protected RecipeDto()
    {
        Title = null!;
        Description = null!;
        CategoryIds = null!;
        IngredientEntries = null!;
        Preparation = null!;
    }

    public long? Id { get; set; }

    [Required] [StringLength(64)] public string Title { get; set; }

    [Required] [StringLength(2048)] public string Description { get; set; }

    public int SuitableFor { get; set; }

    public IList<long> CategoryIds { get; set; }

    public IList<IngredientEntryDto> IngredientEntries { get; set; }

    public IList<PreparationStepDto> Preparation { get; set; }
}