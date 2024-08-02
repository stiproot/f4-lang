using Microsoft.Extensions.DependencyInjection;

internal static class InitDocLoader
{
    public static async Task LoadAsync()
    {
        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .BuildServiceProvider();

        var documentLoader = provider.GetService<IDocumentLoader>()!;

        var documents = new List<DocumentModel>
        {
            new() 
            { 
                CollectionName = "", 
                Id = "", 
                FilePath = "" 
            },
        };

        await documentLoader.LoadAsync(documents);
    }
}