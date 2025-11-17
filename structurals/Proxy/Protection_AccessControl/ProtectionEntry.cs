using Proxy.Protection_AccessControl.Implementations;
using Proxy.Protection_AccessControl.Model;
using Proxy.Protection_AccessControl.Proxies;

namespace Proxy.Protection_AccessControl;

public sealed class ProtectionEntry
{
    public static void Start()
    {
        // STEP 1: Create real account
        var account = new BankAccount("ACC-12345", 5000m);

        // STEP 2: Regular user with limited permissions
        var regularUser = new User
        {
            Name = "John",
            Role = "Customer",
            Permissions = new List<string> { "READ", "WRITE" }
        };

        var regularProxy = new BankAccountProxy(account, regularUser);

        Console.WriteLine("=== Regular User Access ===\n");

        // Can view balance
        regularProxy.GetBalance();

        // Can deposit
        regularProxy.Deposit(100m);

        // Can withdraw small amounts
        regularProxy.Withdraw(50m);

        try
        {
            // Cannot withdraw large amounts
            regularProxy.Withdraw(1500m);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"[Error] {ex.Message}");
        }

        try
        {
            // Cannot view history
            regularProxy.ViewTransactionHistory();
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"[Error] {ex.Message}");
        }

        // STEP 3: Admin user with full permissions
        var adminUser = new User
        {
            Name = "Alice",
            Role = "Admin",
            Permissions = new List<string> { "READ", "WRITE", "ADMIN" }
        };

        var adminProxy = new BankAccountProxy(account, adminUser);

        Console.WriteLine("\n=== Admin User Access ===\n");

        // Can withdraw large amounts
        adminProxy.Withdraw(1500m);

        // Can view transaction history
        adminProxy.ViewTransactionHistory();

        // STEP 4: Read-only user
        var readOnlyUser = new User
        {
            Name = "Bob",
            Role = "Viewer",
            Permissions = new List<string> { "READ" }
        };

        var readOnlyProxy = new BankAccountProxy(account, readOnlyUser);

        Console.WriteLine("\n=== Read-Only User Access ===\n");

        // Can only view balance
        readOnlyProxy.GetBalance();

        try
        {
            // Cannot deposit
            readOnlyProxy.Deposit(100m);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"[Error] {ex.Message}");
        }
    }
}

// OUTPUT:
/*
=== Regular User Access ===

[Proxy] User John viewing balance
[BankAccount] Current balance: $5,000.00
[Proxy] User John depositing $100.00
[BankAccount] Deposited $100.00. New balance: $5,100.00
[Proxy] User John withdrawing $50.00
[BankAccount] Withdrew $50.00. New balance: $5,050.00
[Error] Only admins can withdraw more than $1000
[Error] Only admins can view transaction history

=== Admin User Access ===

[Proxy] User Alice withdrawing $1,500.00
[BankAccount] Withdrew $1,500.00. New balance: $3,550.00
[Proxy] Admin Alice viewing transaction history
[BankAccount] Transaction History:
  - Account opened with $5,000.00
  - Deposit: $100.00
  - Withdrawal: $50.00
  - Withdrawal: $1,500.00

=== Read-Only User Access ===

[Proxy] User Bob viewing balance
[BankAccount] Current balance: $3,550.00
[Error] You don't have permission to deposit
*/
