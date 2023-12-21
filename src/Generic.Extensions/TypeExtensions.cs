namespace Generic.Extensions;

public static class TypeExtensions
{
    public static bool ImplementsIEnumerable(this Type @this)
    {
        return
            @this.IsGenericType &&
            @this.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
    }
}
