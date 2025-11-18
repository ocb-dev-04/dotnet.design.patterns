using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Implementations;

// STEP 2: Concrete Implementors
public class MongoDbProvider : IDatabaseProvider
{
    private bool _connected = false;

    public void Connect(string connectionString)
    {
        Console.WriteLine($"[MongoDB] Connecting to: {connectionString}");
        _connected = true;
        Console.WriteLine("[MongoDB] ✓ Connected");
    }

    public void ExecuteQuery(string query)
    {
        // MongoDB uses different query language
        Console.WriteLine($"[MongoDB] Executing document query: {query}");
        Console.WriteLine("[MongoDB] ✓ Query executed");
    }

    public List<Dictionary<string, object>> FetchResults(string query)
    {
        Console.WriteLine($"[MongoDB] Finding documents: {query}");
        return new List<Dictionary<string, object>>
        {
            new() { ["_id"] = "507f1f77bcf86cd799439011", ["name"] = "MongoDB Doc 1" },
            new() { ["_id"] = "507f1f77bcf86cd799439012", ["name"] = "MongoDB Doc 2" }
        };
    }

    public void Disconnect()
    {
        Console.WriteLine("[MongoDB] Disconnecting...");
        _connected = false;
    }

    public string GetProviderName() => "MongoDB";
}