using Bridge.DatabaseAbstraction.Abstractions;

namespace Bridge.DatabaseAbstraction.Repositories;

// STEP 4: Refined Abstractions
public class UserRepository : Repository
{
    public UserRepository(IDatabaseProvider provider, string connectionString)
        : base(provider, connectionString) { }

    public override void Save(string data)
    {
        Console.WriteLine($"\n[UserRepository] Saving user: {data}");
        _provider.Connect(_connectionString);
        _provider.ExecuteQuery($"INSERT INTO Users VALUES ('{data}')");
        _provider.Disconnect();
    }

    public override List<Dictionary<string, object>> FindAll()
    {
        Console.WriteLine("\n[UserRepository] Finding all users");
        _provider.Connect(_connectionString);
        var results = _provider.FetchResults("SELECT * FROM Users");
        _provider.Disconnect();
        return results;
    }

    public override void Delete(int id)
    {
        Console.WriteLine($"\n[UserRepository] Deleting user {id}");
        _provider.Connect(_connectionString);
        _provider.ExecuteQuery($"DELETE FROM Users WHERE Id = {id}");
        _provider.Disconnect();
    }
}
