/*
ABSTRACT FACTORY PATTERN
🎯Purpose
"Provides an interface for creating families of related objects without specifying their concrete classes"
📊 When to Use

✅ When you need to create families of related objects
✅ When products must be used together
✅ When you want to enforce consistency among products
✅ Multi-platform UI components

⚠️ When NOT to Use

❌ If you don't have product families
❌ If products aren't related
 */

using Abstract.Factory.Factory;

// Determine platform at runtime
string platform = Environment.OSVersion.Platform == PlatformID.Win32NT
            ? "Windows"
            : "Mac";

// Create appropriate factory
IUIFactory factory = platform == "Windows"
    ? new WindowsUIFactory()
    : new MacUIFactory();

Console.WriteLine($"=== Running on {platform} ===\n");

// Create and run application
Application app = new (factory);
app.Run();

// OUTPUT (Windows):
/*
=== Running on Windows ===

[Application] Initializing UI components...

[Windows Factory] Creating Windows Button
[Windows Factory] Creating Windows TextBox
[Windows Factory] Creating Windows CheckBox

[Application] Rendering UI...

[Windows Button] ┌─────────┐
[Windows Button] │  Click  │
[Windows Button] └─────────┘
[Windows TextBox] ┌──────────────┐
[Windows TextBox] │              │
[Windows TextBox] └──────────────┘
[Windows CheckBox] ☐ Option

[Application] Interacting with UI...

[Windows Button] Button clicked with Windows style
[Windows TextBox] Text set to: Hello
[Windows CheckBox] Toggled to: True

[Application] Rendering updated UI...

[Windows TextBox] ┌──────────────┐
[Windows TextBox] │ Hello        │
[Windows TextBox] └──────────────┘
[Windows CheckBox] ☑ Option
*/