namespace Singleton;

// EXPLANATION: Most common and recommended approach in .NET
// Uses Lazy<T> which is thread-safe by default
public sealed class Logger
{
    // Step 1: Private static Lazy instance
    // Explanation: Lazy<T> ensures thread-safe initialization on first access
    // sealed prevents inheritance
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

    // Step 2: Public property to access instance
    // Explanation: This is the global access point
    public static Logger Instance => _instance.Value;

    // Step 3: Private constructor prevents direct instantiation
    // Explanation: No one can use 'new Logger()' outside this class
    private Logger()
    {
        // Initialize resources
        Console.WriteLine("[Singleton] Logger instance created");
    }

    // Step 4: Instance methods
    public void Log(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[{timestamp}] {message}");
    }

    public void LogError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Log($"ERROR: {error}");
        Console.ResetColor();
    }
}