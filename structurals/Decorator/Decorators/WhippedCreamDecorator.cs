using Decorator.Abstractions;
using Decorator.Decorators.Base;

namespace Decorator.Decorators;

// STEP 4: Concrete Decorators
// Explanation: Each decorator adds specific functionality

// Whipped Cream Decorator
public class WhippedCreamDecorator : CoffeeDecorator
{
    public WhippedCreamDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Whipped Cream";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.75m;
    }
}
