using Abstract.Factory.Abstractions;
using Abstract.Factory.Implementations;

namespace Abstract.Factory.Factory;

// STEP 5: Concrete Factories
public class MacUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        Console.WriteLine("[Mac Factory] Creating Mac Button");
        return new MacButton();
    }

    public ITextBox CreateTextBox()
    {
        Console.WriteLine("[Mac Factory] Creating Mac TextBox");
        return new MacTextBox();
    }

    public ICheckBox CreateCheckBox()
    {
        Console.WriteLine("[Mac Factory] Creating Mac CheckBox");
        return new MacCheckBox();
    }
}