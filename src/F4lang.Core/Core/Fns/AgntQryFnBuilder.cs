namespace F4lang.Core;

public class AgntQryFnBuilder : IFnBuilder
{
    private readonly Dictionary<string, IAgntManager> _agntManagerHash = new();
    public string Key => FnNames.AGENT_QRY;

    public Delegate Build()
    {
        return (string agntId, string qry) => 
        {
            Console.WriteLine($"Invoking function: {Key}");

            var agntQry = new AgntManagerQry { RawTxtQry = qry };

            return this._agntManagerHash[agntId].ManageAsync(agntQry, default).Result;
        };
    }
}