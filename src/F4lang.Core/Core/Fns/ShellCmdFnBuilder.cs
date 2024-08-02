using System.Diagnostics;

namespace F4lang.Core;

public class ShellCmdFnBuilder : IFnBuilder
{
    public string Key => FnNames.SHELL_CMD;

    private Process ProcFactory(ProcessStartInfo processStartInfo) 
        => new Process{ StartInfo = processStartInfo };

    public Delegate Build()
    {
        return (string shellCmd) =>
        {
            Console.WriteLine($"Invoking function: {this.Key}");

            var procStartInfo = new ProcessStartInfo
            {
                FileName = "bash",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"-c \"{shellCmd}\""
            };

            var proc = this.ProcFactory(procStartInfo);

            proc.Start();
            proc.WaitForExit();

            string output = proc.StandardOutput.ReadToEnd();
            string error = proc.StandardError.ReadToEnd();

            Console.WriteLine("Output:");
            Console.WriteLine(output);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error:");
                Console.WriteLine(error);
            }
        };
    }
}