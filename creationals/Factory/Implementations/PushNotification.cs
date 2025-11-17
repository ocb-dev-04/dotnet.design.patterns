using Factory.Abstractions;

namespace Factory.Implementations;

// STEP 2: Concrete Products
public class PushNotification : INotification
{
    public async Task SendAsync(string recipient, string message)
    {
        Console.WriteLine($"[Push] Sending to device: {recipient}");
        Console.WriteLine($"[Push] Message: {message}");
        await Task.Delay(75); // Simulate FCM
        Console.WriteLine("[Push] ✓ Sent successfully");
    }

    public string GetChannelType() => "Push";
}
