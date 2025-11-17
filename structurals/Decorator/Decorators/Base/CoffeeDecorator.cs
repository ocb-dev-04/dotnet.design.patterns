using Decorator.Abstractions;

namespace Decorator.Decorators.Base;

// STEP 3: Base Decorator (Abstract)
// Explanation: Holds reference to wrapped object and delegates calls
public abstract class CoffeeDecorator : ICoffee
{
    protected readonly ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee ?? throw new ArgumentNullException(nameof(coffee));
    }

    // Delegate to wrapped object by default
    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual decimal GetCost() => _coffee.GetCost();
}
