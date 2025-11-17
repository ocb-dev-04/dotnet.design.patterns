using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 3: Concrete Products - Mac Style
public class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("[Mac Button] ╭─────────╮");
        Console.WriteLine("[Mac Button] │  Click  │");
        Console.WriteLine("[Mac Button] ╰─────────╯");
    }

    public void Click()
    {
        Console.WriteLine("[Mac Button] Button clicked with Mac style");
    }
}
