using Decorator.Abstractions;
using Decorator.Decorators.Base;

namespace Decorator.Decorators;

// STEP 4: Concrete Decorators
// Explanation: Each decorator adds specific functionality

// Sugar Decorator - adds sugar
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Sugar";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.25m;
    }
}
