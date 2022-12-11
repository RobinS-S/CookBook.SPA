namespace CookBook.Data.SeedWork;

public abstract class ValueObject<T>
    where T : ValueObject<T>
{
    public override bool Equals(object? obj)
    {
        return obj is T valueObject && EqualsCore(valueObject);
    }

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    protected abstract bool EqualsCore(T other);

    protected abstract int GetHashCodeCore();

    public static bool operator ==(ValueObject<T>? first, ValueObject<T>? second)
    {
        if (first is null && second is null) return true;

        if (first is null || second is null) return false;

        return first.Equals(second);
    }

    public static bool operator !=(ValueObject<T>? first, ValueObject<T>? second)
    {
        return !(first == second);
    }
}