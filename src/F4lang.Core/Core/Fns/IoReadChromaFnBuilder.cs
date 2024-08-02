using System.Text;
using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

namespace F4lang.Core;

public class IoReadChromaFnBuilder(IFactory<ISemanticTextMemory> factory) : IFnBuilder
{
    public string Key => FnNames.IO_READ_VECTOR_STORE;
    private readonly ISemanticTextMemory _semanticTextMemory = factory.Create();
    private StringBuilder SbFactory() => new();

    public Delegate Build()
    {
        return (string collection, string qry) => 
        {
            Console.WriteLine($"Invoking function: {this.Key}");

            var res = this._semanticTextMemory.SearchAsync(collection, qry).ToListAsync().Result;
            var builder = this.SbFactory();

            foreach(var r in res)
            {
                builder.Append(r.Metadata.Text);
                builder.AppendLine();
            }

            return builder.ToString();
        };
    }
}