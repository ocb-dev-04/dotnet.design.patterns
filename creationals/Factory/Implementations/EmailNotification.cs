using Factory.Abstractions;

namespace Factory.Implementations;


// STEP 2: Concrete Products
public class EmailNotification : INotification
{
    public async Task SendAsync(string recipient, string message)
    {
        Console.WriteLine($"[Email] Sending to: {recipient}");
        Console.WriteLine($"[Email] Message: {message}");
        await Task.Delay(100); // Simulate SMTP
        Console.WriteLine("[Email] ✓ Sent successfully");
    }

    public string GetChannelType() => "Email";
}
