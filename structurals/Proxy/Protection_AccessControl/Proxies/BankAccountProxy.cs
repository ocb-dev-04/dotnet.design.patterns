using Proxy.Protection_AccessControl.Abstractions;
using Proxy.Protection_AccessControl.Implementations;
using Proxy.Protection_AccessControl.Model;

namespace Proxy.Protection_AccessControl.Proxies;


// STEP 3: Protection Proxy
// Explanation: Controls access based on user permissions
public class BankAccountProxy : IBankAccount
{
    private readonly BankAccount _realAccount;
    private readonly User _currentUser;

    public BankAccountProxy(BankAccount realAccount, User currentUser)
    {
        _realAccount = realAccount;
        _currentUser = currentUser;
    }

    public decimal GetBalance()
    {
        // STEP 1: Check permission
        if (!HasPermission("READ"))
        {
            throw new UnauthorizedAccessException("You don't have permission to view balance");
        }

        // STEP 2: Log access
        Console.WriteLine($"[Proxy] User {_currentUser.Name} viewing balance");

        // STEP 3: Delegate to real object
        return _realAccount.GetBalance();
    }

    public void Withdraw(decimal amount)
    {
        // STEP 1: Check permission
        if (!HasPermission("WRITE"))
        {
            throw new UnauthorizedAccessException("You don't have permission to withdraw");
        }

        // STEP 2: Additional validation (business rule)
        if (amount > 1000 && _currentUser.Role != "Admin")
        {
            throw new UnauthorizedAccessException("Only admins can withdraw more than $1000");
        }

        // STEP 3: Log action
        Console.WriteLine($"[Proxy] User {_currentUser.Name} withdrawing {amount:C}");

        // STEP 4: Delegate to real object
        _realAccount.Withdraw(amount);
    }

    public void Deposit(decimal amount)
    {
        // STEP 1: Check permission
        if (!HasPermission("WRITE"))
        {
            throw new UnauthorizedAccessException("You don't have permission to deposit");
        }

        // STEP 2: Log action
        Console.WriteLine($"[Proxy] User {_currentUser.Name} depositing {amount:C}");

        // STEP 3: Delegate
        _realAccount.Deposit(amount);
    }

    public void ViewTransactionHistory()
    {
        // STEP 1: Check special permission
        if (!HasPermission("ADMIN"))
        {
            throw new UnauthorizedAccessException("Only admins can view transaction history");
        }

        Console.WriteLine($"[Proxy] Admin {_currentUser.Name} viewing transaction history");
        _realAccount.ViewTransactionHistory();
    }

    private bool HasPermission(string permission)
    {
        // Explanation: Check user permissions
        return _currentUser.Permissions.Contains(permission);
    }
}