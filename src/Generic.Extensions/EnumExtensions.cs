namespace Generic.Extensions;

public static class EnumExtensions
{
    public static IEnumerable<T> EnumToList<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}
