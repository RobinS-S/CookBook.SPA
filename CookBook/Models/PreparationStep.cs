using CookBook.Data.SeedWork;

namespace CookBook.Models;

public class PreparationStep
    : Entity
{
    public PreparationStep(int position, string description)
    {
        Position = position;
        Description = description;
    }

    private PreparationStep()
    {
        Description = null!;
    }

    public int Position { get; set; }

    public string Description { get; set; }
}