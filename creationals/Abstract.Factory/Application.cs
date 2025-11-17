


// STEP 6: Client Code
// Explanation: Works with factory interface, doesn't know concrete types
using Abstract.Factory.Abstractions;
using Abstract.Factory.Factory;

public class Application
{
    private readonly IButton _button;
    private readonly ITextBox _textBox;
    private readonly ICheckBox _checkBox;

    // Step 1: Constructor receives factory
    // Explanation: Application doesn't know if it's Windows or Mac
    public Application(IUIFactory factory)
    {
        Console.WriteLine("[Application] Initializing UI components...\n");

        // Step 2: Create components using factory
        _button = factory.CreateButton();
        _textBox = factory.CreateTextBox();
        _checkBox = factory.CreateCheckBox();
    }

    // Step 3: Use components (same code for all platforms)
    public void Run()
    {
        Console.WriteLine("\n[Application] Rendering UI...\n");

        _button.Render();
        _textBox.Render();
        _checkBox.Render();

        Console.WriteLine("\n[Application] Interacting with UI...\n");

        _button.Click();
        _textBox.SetText("Hello");
        _checkBox.Toggle();

        Console.WriteLine("\n[Application] Rendering updated UI...\n");

        _textBox.Render();
        _checkBox.Render();
    }
}