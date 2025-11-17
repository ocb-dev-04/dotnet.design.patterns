namespace Decorator.Abstractions;

// STEP 1: Base Interface
// Explanation: Common contract for both coffee and decorators
public interface ICoffee
{
    string GetDescription();
    decimal GetCost();
}
