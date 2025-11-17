using Abstract.Factory.Abstractions;
using Abstract.Factory.Implementations;

namespace Abstract.Factory.Factory;

// STEP 5: Concrete Factories
public class WindowsUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        Console.WriteLine("[Windows Factory] Creating Windows Button");
        return new WindowsButton();
    }

    public ITextBox CreateTextBox()
    {
        Console.WriteLine("[Windows Factory] Creating Windows TextBox");
        return new WindowsTextBox();
    }

    public ICheckBox CreateCheckBox()
    {
        Console.WriteLine("[Windows Factory] Creating Windows CheckBox");
        return new WindowsCheckBox();
    }
}
