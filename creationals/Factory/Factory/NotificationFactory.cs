using Factory.Abstractions;

namespace Factory.Factory;

// STEP 3: Creator (Abstract Factory)
public abstract class NotificationFactory
{
    // Factory Method - implemented by subclasses
    public abstract INotification CreateNotification();

    // Template method using factory
    public async Task NotifyUser(string recipient, string message)
    {
        // Step 1: Create notification using factory method
        var notification = CreateNotification();

        // Step 2: Log and send
        Console.WriteLine($"Using channel: {notification.GetChannelType()}");
        await notification.SendAsync(recipient, message);
    }
}
