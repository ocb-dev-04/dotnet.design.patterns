using Decorator.Abstractions;

namespace Decorator.Implementations;

// STEP 2: Concrete Component (Simple Coffee)
// Explanation: The basic object we'll decorate
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";
    public decimal GetCost() => 2.00m;
}
