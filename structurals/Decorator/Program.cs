using Decorator.Abstractions;
using Decorator.Decorators;
using Decorator.Implementations;

// STEP 1: Start with simple coffee
ICoffee coffee = new SimpleCoffee();
Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
// Output: Simple Coffee - $2.00

// STEP 2: Add milk (wrap with MilkDecorator)
// Explanation: MilkDecorator wraps SimpleCoffee
coffee = new MilkDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
// Output: Simple Coffee, Milk - $2.50

// STEP 3: Add sugar (wrap with SugarDecorator)
// Explanation: SugarDecorator wraps MilkDecorator which wraps SimpleCoffee
coffee = new SugarDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
// Output: Simple Coffee, Milk, Sugar - $2.75

// STEP 4: Add whipped cream
// Explanation: Stack grows - WhippedCream → Sugar → Milk → SimpleCoffee
coffee = new WhippedCreamDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
// Output: Simple Coffee, Milk, Sugar, Whipped Cream - $3.50

// VISUALIZATION OF CALL STACK:
/*
GetCost() call flow:
WhippedCreamDecorator.GetCost()
    → SugarDecorator.GetCost()
        → MilkDecorator.GetCost()
            → SimpleCoffee.GetCost() = 2.00
        ← + 0.50 = 2.50
    ← + 0.25 = 2.75
← + 0.75 = 3.50
*/