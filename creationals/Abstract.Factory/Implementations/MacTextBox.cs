using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 3: Concrete Products - Mac Style
public class MacTextBox : ITextBox
{
    private string _text = "";

    public void Render()
    {
        Console.WriteLine("[Mac TextBox] ╭──────────────╮");
        Console.WriteLine($"[Mac TextBox] │ {_text,-12} │");
        Console.WriteLine("[Mac TextBox] ╰──────────────╯");
    }

    public void SetText(string text)
    {
        _text = text;
        Console.WriteLine($"[Mac TextBox] Text set to: {text}");
    }
}
