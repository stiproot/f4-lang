
using System.Text;

namespace F4lang.Core.Agnts;

public record AgntChat
{
    public string SysPrompt { get; init; } = string.Empty;
    public IEnumerable<string> FnNames { get; init; } = [];
    public IEnumerable<string> AgntNames { get; init; } = [];
    public IEnumerable<string> Collections { get; init; } = [];
    public IList<AgntChatHistory> ChatHistory { get; init; } = [];
    public IList<string> FnInvocations { get; init; } = [];
    public IList<string> AdditionalContext { get; init; } = [];
    
    public AgntChat AddAgntChatHistory(AgntChatHistory agntChatHistory)
    {
        this.ChatHistory.Add(agntChatHistory);
        return this;
    }

    public AgntChat AddContext(string context)
    {
        this.AdditionalContext.Add(context);
        return this; 
    }

    public virtual string BuildUsrChatHistory()
    {
        if(!this.ChatHistory.Any()) return string.Empty;

        var history = this.ChatHistory.Where(c => c.AgntChatType == AgntChatHistoryTypes.Usr).Select(c => c.ToStr());

        if(!history.Any()) return string.Empty;

        var builder = new StringBuilder();

        builder.AppendLine("<chat_history>");
        builder.AppendLine(string.Join("\n", history));
        builder.AppendLine("</chat_history>");

        return builder.ToString();
    }

    public virtual string Build()
    {
        var builder = new StringBuilder();

        builder.AppendLine("<sys_prompt>");
        builder.AppendLine(this.SysPrompt);

        if(this.FnNames.Any())
        {
            builder.AppendLine("<agnt_functions_available>");
            builder.AppendLine(string.Join("\n", this.FnNames.Select(n => $"- {n}")));
            builder.AppendLine("</agnt_functions_available>");
        }

        if(this.AgntNames.Any())
        {
            builder.AppendLine("<agnts_available>");
            builder.AppendLine(string.Join("\n", this.AgntNames.Select(n => $"- {n}")));
            builder.AppendLine("</agnts_available>");
        }

        if(this.Collections.Any())
        {
            builder.AppendLine("<vector_store_collections_available>");
            builder.AppendLine(string.Join("\n", this.Collections.Select(n => $"- {n}")));
            builder.AppendLine("</vector_store_collections_available>");
        }

        if(this.AdditionalContext.Any())
        {
            builder.AppendLine("<additional_context>");
            builder.AppendLine(string.Join("\n", this.AdditionalContext.Select(n => $"- {n}")));
            builder.AppendLine("</additional_context>");
        }

        builder.AppendLine("</sys_prompt>");
        builder.AppendLine();

        if(this.ChatHistory.Any())
        {
            builder.AppendLine("<chat_history>");
            builder.AppendLine(string.Join("\n", ChatHistory.Select(c => c.ToStr())));
            builder.AppendLine("</chat_history>");
        }

        return builder.ToString();
    }
}