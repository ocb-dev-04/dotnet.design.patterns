using Bridge.DatabaseAbstraction.Repositories;
using Bridge.DatabaseAbstraction.Implementations;

namespace Bridge.DatabaseAbstraction;

public sealed class DatabaseEntry
{
    public static void DemonstratePattern()
    {
        // Example 1: UserRepository with SQL Server
        Console.WriteLine("=== Example 1: User Repository with SQL Server ===");

        var sqlProvider = new SqlServerProvider();
        var userRepo = new UserRepository(sqlProvider, "Server=localhost;Database=MyApp;");

        userRepo.Save("John Doe");
        var users = userRepo.FindAll();
        Console.WriteLine($"Found {users.Count} users");
        userRepo.Delete(1);

        // Example 2: Switch to PostgreSQL at runtime
        Console.WriteLine("\n=== Example 2: Switch to PostgreSQL ===");

        var postgresProvider = new PostgreSqlProvider();
        userRepo.ChangeProvider(postgresProvider);

        userRepo.Save("Jane Smith");
        users = userRepo.FindAll();
        Console.WriteLine($"Found {users.Count} users");

        // Example 3: ProductRepository with MongoDB
        Console.WriteLine("\n=== Example 3: Product Repository with MongoDB ===");

        var mongoProvider = new MongoDbProvider();
        var productRepo = new ProductRepository(mongoProvider, "mongodb://localhost:27017/myapp");

        productRepo.Save("Laptop");
        var products = productRepo.FindAll();
        Console.WriteLine($"Found {products.Count} products");

        // Example 4: Same ProductRepository, different provider
        Console.WriteLine("\n=== Example 4: Product Repository with SQL Server ===");

        productRepo.ChangeProvider(sqlProvider);
        productRepo.Save("Mouse");
        products = productRepo.FindAll();
        Console.WriteLine($"Found {products.Count} products");
    }
}

// OUTPUT:
/*
=== Example 1: User Repository with SQL Server ===

[UserRepository] Saving user: John Doe
[SQL Server] Connecting to: Server=localhost;Database=MyApp;
[SQL Server] ✓ Connected
[SQL Server] Executing: INSERT INTO Users VALUES ('John Doe')
[SQL Server] ✓ Query executed
[SQL Server] Disconnecting...

[UserRepository] Finding all users
[SQL Server] Connecting to: Server=localhost;Database=MyApp;
[SQL Server] ✓ Connected
[SQL Server] Fetching: SELECT * FROM Users
[SQL Server] Disconnecting...
Found 2 users

[UserRepository] Deleting user 1
[SQL Server] Connecting to: Server=localhost;Database=MyApp;
[SQL Server] ✓ Connected
[SQL Server] Executing: DELETE FROM Users WHERE Id = 1
[SQL Server] ✓ Query executed
[SQL Server] Disconnecting...

=== Example 2: Switch to PostgreSQL ===

[Repository] Switching from SQL Server to PostgreSQL
[SQL Server] Disconnecting...

[UserRepository] Saving user: Jane Smith
[PostgreSQL] Connecting to: Server=localhost;Database=MyApp;
[PostgreSQL] ✓ Connected
[PostgreSQL] Executing: INSERT INTO Users VALUES ('Jane Smith')
[PostgreSQL] ✓ Query executed
[PostgreSQL] Disconnecting...

[UserRepository] Finding all users
[PostgreSQL] Connecting to: Server=localhost;Database=MyApp;
[PostgreSQL] ✓ Connected
[PostgreSQL] Fetching: SELECT * FROM Users
[PostgreSQL] Disconnecting...
Found 2 users

=== Example 3: Product Repository with MongoDB ===

[ProductRepository] Saving product: Laptop
[MongoDB] Connecting to: mongodb://localhost:27017/myapp
[MongoDB] ✓ Connected
[MongoDB] Executing document query: INSERT INTO Products VALUES ('Laptop')
[MongoDB] ✓ Query executed
[MongoDB] Disconnecting...

[ProductRepository] Finding all products
[MongoDB] Connecting to: mongodb://localhost:27017/myapp
[MongoDB] ✓ Connected
[MongoDB] Finding documents: SELECT * FROM Products
[MongoDB] Disconnecting...
Found 2 products

=== Example 4: Product Repository with SQL Server ===

[Repository] Switching from MongoDB to SQL Server
[MongoDB] Disconnecting...

[ProductRepository] Saving product: Mouse
[SQL Server] Connecting to: mongodb://localhost:27017/myapp
[SQL Server] ✓ Connected
[SQL Server] Executing: INSERT INTO Products VALUES ('Mouse')
[SQL Server] ✓ Query executed
[SQL Server] Disconnecting...

[ProductRepository] Finding all products
[SQL Server] Connecting to: mongodb://localhost:27017/myapp
[SQL Server] ✓ Connected
[SQL Server] Fetching: SELECT * FROM Products
[SQL Server] Disconnecting...
Found 2 products
*/