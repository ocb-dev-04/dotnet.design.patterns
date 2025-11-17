using Strategy.Enums;
using Strategy.Models;

namespace Strategy.Strategies;

public sealed class PushStrategy : INotificationStrategy
{
    // Explanation: Each strategy knows which type it handles
    public NotificationType SupportedType => NotificationType.Push;

    public void ProcessNotifications(Notification model)
    {
        // Explanation: Encapsulates credit card specific logic
        Console.WriteLine($"Sending PUSH notification to device {model.Recipient}");
        Console.WriteLine($"Title: {model.Subject}");
        Console.WriteLine($"Body: {model.Message}");
    }
}
