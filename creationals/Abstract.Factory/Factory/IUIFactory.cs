using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Factory;

// STEP 4: Abstract Factory Interface
// Explanation: Declares creation methods for each product type
public interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
    ICheckBox CreateCheckBox();
}
