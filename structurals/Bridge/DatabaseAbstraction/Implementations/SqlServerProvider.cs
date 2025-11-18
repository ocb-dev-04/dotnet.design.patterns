using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Implementations;


// STEP 2: Concrete Implementors
public class SqlServerProvider : IDatabaseProvider
{
    private bool _connected = false;

    public void Connect(string connectionString)
    {
        Console.WriteLine($"[SQL Server] Connecting to: {connectionString}");
        _connected = true;
        Console.WriteLine("[SQL Server] ✓ Connected");
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"[SQL Server] Executing: {query}");
        Console.WriteLine("[SQL Server] ✓ Query executed");
    }

    public List<Dictionary<string, object>> FetchResults(string query)
    {
        Console.WriteLine($"[SQL Server] Fetching: {query}");
        return new List<Dictionary<string, object>>
        {
            new() { ["Id"] = 1, ["Name"] = "SQL Result 1" },
            new() { ["Id"] = 2, ["Name"] = "SQL Result 2" }
        };
    }

    public void Disconnect()
    {
        Console.WriteLine("[SQL Server] Disconnecting...");
        _connected = false;
    }

    public string GetProviderName() => "SQL Server";
}
