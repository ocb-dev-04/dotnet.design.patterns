using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Implementations;

// STEP 2: Concrete Implementors
public class PostgreSqlProvider : IDatabaseProvider
{
    private bool _connected = false;

    public void Connect(string connectionString)
    {
        Console.WriteLine($"[PostgreSQL] Connecting to: {connectionString}");
        _connected = true;
        Console.WriteLine("[PostgreSQL] ✓ Connected");
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"[PostgreSQL] Executing: {query}");
        Console.WriteLine("[PostgreSQL] ✓ Query executed");
    }

    public List<Dictionary<string, object>> FetchResults(string query)
    {
        Console.WriteLine($"[PostgreSQL] Fetching: {query}");
        return new List<Dictionary<string, object>>
        {
            new() { ["id"] = 1, ["name"] = "PostgreSQL Result 1" },
            new() { ["id"] = 2, ["name"] = "PostgreSQL Result 2" }
        };
    }

    public void Disconnect()
    {
        Console.WriteLine("[PostgreSQL] Disconnecting...");
        _connected = false;
    }

    public string GetProviderName() => "PostgreSQL";
}
