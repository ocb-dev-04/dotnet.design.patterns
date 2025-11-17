using Strategy.Enums;
using Strategy.Models;

namespace Strategy.Strategies;

public sealed class SMSStrategy : INotificationStrategy
{
    // Explanation: Each strategy knows which type it handles
    public NotificationType SupportedType => NotificationType.SMS;

    public void ProcessNotifications(Notification model)
    {
        // Explanation: Encapsulates credit card specific logic
        Console.WriteLine($"Sending SMS to {model.Recipient}");
        Console.WriteLine($"Message: {model.Message}");
    }
}
