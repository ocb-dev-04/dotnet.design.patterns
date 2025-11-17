namespace Proxy.Protection_AccessControl.Abstractions;

// STEP 1: Subject Interface
public interface IBankAccount
{
    decimal GetBalance();
    void Withdraw(decimal amount);
    void Deposit(decimal amount);
    void ViewTransactionHistory();
}