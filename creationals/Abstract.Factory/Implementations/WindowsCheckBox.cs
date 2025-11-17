using Abstract.Factory.Abstractions;

namespace Abstract.Factory.Implementations;

// STEP 2: Concrete Products - Windows Style
public class WindowsCheckBox : ICheckBox
{
    private bool _checked = false;

    public void Render()
    {
        var state = _checked ? "☑" : "☐";
        Console.WriteLine($"[Windows CheckBox] {state} Option");
    }

    public void Toggle()
    {
        _checked = !_checked;
        Console.WriteLine($"[Windows CheckBox] Toggled to: {_checked}");
    }
}