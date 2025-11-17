using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 3: Concrete Products - Mac Style
public class MacCheckBox : ICheckBox
{
    private bool _checked = false;

    public void Render()
    {
        var state = _checked ? "◉" : "○";
        Console.WriteLine($"[Mac CheckBox] {state} Option");
    }

    public void Toggle()
    {
        _checked = !_checked;
        Console.WriteLine($"[Mac CheckBox] Toggled to: {_checked}");
    }
}