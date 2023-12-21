namespace Generic.Extensions;

public static class OptionsExtensions
{
    public static IServiceCollection ConfigureOptions<T>(
        this IServiceCollection @this,
        IConfiguration configuration,
        string sectionName
    ) where T : class
    {
        @this.Configure<T>(configuration.GetSection(sectionName));
        return @this;
    }
}
