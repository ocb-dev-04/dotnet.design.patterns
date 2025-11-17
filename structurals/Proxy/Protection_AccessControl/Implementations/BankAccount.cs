using Proxy.Protection_AccessControl.Abstractions;

namespace Proxy.Protection_AccessControl.Implementations;

// STEP 2: Real Subject
// Explanation: Actual bank account with sensitive operations
public class BankAccount : IBankAccount
{
    private decimal _balance;
    private readonly List<string> _transactions = new();
    public string AccountNumber { get; }

    public BankAccount(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        _balance = initialBalance;
        _transactions.Add($"Account opened with {initialBalance:C}");
    }

    public decimal GetBalance()
    {
        Console.WriteLine($"[BankAccount] Current balance: {_balance:C}");
        return _balance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds");

        _balance -= amount;
        _transactions.Add($"Withdrawal: {amount:C}");
        Console.WriteLine($"[BankAccount] Withdrew {amount:C}. New balance: {_balance:C}");
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        _transactions.Add($"Deposit: {amount:C}");
        Console.WriteLine($"[BankAccount] Deposited {amount:C}. New balance: {_balance:C}");
    }

    public void ViewTransactionHistory()
    {
        Console.WriteLine("[BankAccount] Transaction History:");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine($"  - {transaction}");
        }
    }
}
