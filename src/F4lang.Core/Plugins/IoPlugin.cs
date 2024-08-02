using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace F4lang.Core.Plugins;

/// <summary>
/// Plugin example with two method functions, where one function gets a random word and the other returns a definition for a given word.
/// </summary>
public sealed class IoPlugin
{
    public const string PluginName = nameof(IoPlugin);

    [KernelFunction, Description("Reads a file and returns the contents as a string.")]
    public string ReadFile([Description("Path to file to read.")] string filePath)
    {
        return File.ReadAllText(filePath);
    }

    [KernelFunction, Description("Writes a string to a file.")]
    public void WriteFile([Description("Path of file to write to.")] string filePath, [Description("String to write to file.")] string contents)
    {
        File.WriteAllText(filePath, contents);
    }
}