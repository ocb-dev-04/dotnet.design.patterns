namespace Bridge.DatabaseAbstraction.Abstractions;

// STEP 1: Implementor - Database Provider
public interface IDatabaseProvider
{
    void Connect(string connectionString);
    void ExecuteQuery(string query);
    List<Dictionary<string, object>> FetchResults(string query);
    void Disconnect();
    string GetProviderName();
}