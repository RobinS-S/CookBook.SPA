namespace CookBook.Data.SeedWork;

public abstract class Entity<T>
{
    public T Id { get; protected set; } = default!;
}

public abstract class Entity : Entity<long>
{
}