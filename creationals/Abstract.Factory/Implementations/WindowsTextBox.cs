using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 2: Concrete Products - Windows Style
public class WindowsTextBox : ITextBox
{
    private string _text = "";

    public void Render()
    {
        Console.WriteLine("[Windows TextBox] ┌──────────────┐");
        Console.WriteLine($"[Windows TextBox] │ {_text,-12} │");
        Console.WriteLine("[Windows TextBox] └──────────────┘");
    }

    public void SetText(string text)
    {
        _text = text;
        Console.WriteLine($"[Windows TextBox] Text set to: {text}");
    }
}
