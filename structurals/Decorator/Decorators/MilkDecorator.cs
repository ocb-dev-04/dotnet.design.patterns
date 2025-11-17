using Decorator.Abstractions;
using Decorator.Decorators.Base;

namespace Decorator.Decorators;

// STEP 4: Concrete Decorators
// Explanation: Each decorator adds specific functionality

// Milk Decorator - adds milk
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        // Explanation: Call wrapped object and ADD to its result
        return _coffee.GetDescription() + ", Milk";
    }

    public override decimal GetCost()
    {
        // Explanation: Add milk cost to base cost
        return _coffee.GetCost() + 0.50m;
    }
}
