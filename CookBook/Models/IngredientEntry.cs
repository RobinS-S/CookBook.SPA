using CookBook.Data.SeedWork;

namespace CookBook.Models;

public sealed class IngredientEntry
    : ValueObject<IngredientEntry>
{
#pragma warning disable IDE0044
#pragma warning restore

    private IngredientEntry(string product, int quantity, string? unit)
    {
        this.Product = product;
        this.Quantity = quantity;
        this.Unit = unit;
    }

    private IngredientEntry()
    {
        Product = null!;
    }

    public string Product { get; }

    public int Quantity { get; }

    public string? Unit { get; }

    public static IngredientEntry Create(string product, int quantity, string? unit = null)
    {
        return new(product, quantity, unit);
    }

    protected override bool EqualsCore(IngredientEntry other)
    {
        return Quantity == other.Quantity && Product == other.Product && Unit == other.Unit;
    }

    protected override int GetHashCodeCore()
    {
        return HashCode.Combine(Product, Quantity, Unit);
    }
}