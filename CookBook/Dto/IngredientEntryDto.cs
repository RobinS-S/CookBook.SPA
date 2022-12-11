namespace CookBook.Dto;

public class IngredientEntryDto
{
    public string Product { get; set; } = null!;

    public int Quantity { get; set; }

    public string? Unit { get; set; }
}