using System.Text;

namespace F4lang.Core.Agnts;

public record AgntChatHistory
{
    public AgntChatHistoryTypes AgntChatType { get; init; } = AgntChatHistoryTypes.Usr; 
    public string? Agnt { get; init; }
    public string? Fn { get; init; } = string.Empty;
    public string? Args { get; init; } = string.Empty;
    public object? FnRes { get; init; }
    public string? Usr { get; init; } = string.Empty;

    public string ToStr()
    {
        if (this.AgntChatType is AgntChatHistoryTypes.Usr)
        {
            return $"Usr: {Usr}\nAgnt: {Agnt}";
        }
        else
        {
            var builder = new StringBuilder();

            // if(this.Agnt is not null)
            // {
            //     builder.AppendLine($"Agnt: {this.Agnt}");
            // }

            builder.AppendLine($"<function_call>");
            builder.AppendLine($"function: {this.Fn}");
            builder.AppendLine($"function call arguments: {this.Args}");
            builder.AppendLine("function call result:");
            builder.AppendLine($"{this.FnRes}");
            builder.AppendLine($"</function_call>");

            return builder.ToString();
        }
    }
}