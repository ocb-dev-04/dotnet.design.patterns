using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Repositories;

// STEP 4: Refined Abstractions
public class ProductRepository : Repository
{
    public ProductRepository(IDatabaseProvider provider, string connectionString)
        : base(provider, connectionString) { }

    public override void Save(string data)
    {
        Console.WriteLine($"\n[ProductRepository] Saving product: {data}");
        _provider.Connect(_connectionString);
        _provider.ExecuteQuery($"INSERT INTO Products VALUES ('{data}')");
        _provider.Disconnect();
    }

    public override List<Dictionary<string, object>> FindAll()
    {
        Console.WriteLine("\n[ProductRepository] Finding all products");
        _provider.Connect(_connectionString);
        var results = _provider.FetchResults("SELECT * FROM Products");
        _provider.Disconnect();
        return results;
    }
    public override void Delete(int id)
    {
        Console.WriteLine($"\n[ProductRepository] Deleting product {id}");
        _provider.Connect(_connectionString);
        _provider.ExecuteQuery($"DELETE FROM Products WHERE Id = {id}");
        _provider.Disconnect();
    }
}