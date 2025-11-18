using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Repositories;

// STEP 3: Abstraction - Repository
public abstract class Repository
{
    protected IDatabaseProvider _provider;
    protected string _connectionString;

    protected Repository(IDatabaseProvider provider, string connectionString)
    {
        _provider = provider;
        _connectionString = connectionString;
    }

    public abstract void Save(string data);
    public abstract List<Dictionary<string, object>> FindAll();
    public abstract void Delete(int id);

    public void ChangeProvider(IDatabaseProvider provider)
    {
        Console.WriteLine($"\n[Repository] Switching from {_provider.GetProviderName()} to {provider.GetProviderName()}");
        _provider.Disconnect();
        _provider = provider;
    }
}
