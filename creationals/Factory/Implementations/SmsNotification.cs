using Factory.Abstractions;

namespace Factory.Implementations;

// STEP 2: Concrete Products
public class SmsNotification : INotification
{
    public async Task SendAsync(string recipient, string message)
    {
        Console.WriteLine($"[SMS] Sending to: {recipient}");
        Console.WriteLine($"[SMS] Message: {message}");
        await Task.Delay(50); // Simulate SMS API
        Console.WriteLine("[SMS] ✓ Sent successfully");
    }

    public string GetChannelType() => "SMS";
}
