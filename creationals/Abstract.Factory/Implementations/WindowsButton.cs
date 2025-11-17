using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 2: Concrete Products - Windows Style
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("[Windows Button] ┌─────────┐");
        Console.WriteLine("[Windows Button] │  Click  │");
        Console.WriteLine("[Windows Button] └─────────┘");
    }

    public void Click()
    {
        Console.WriteLine("[Windows Button] Button clicked with Windows style");
    }
}
