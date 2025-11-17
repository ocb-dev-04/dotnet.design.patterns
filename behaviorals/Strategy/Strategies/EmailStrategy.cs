using Strategy.Enums;
using Strategy.Models;
using Strategy.Strategies.Abstractions;

namespace Strategy.Strategies;

public sealed class EmailStrategy : INotificationStrategy
{
    // Explanation: Each strategy knows which type it handles
    public NotificationType SupportedType => NotificationType.Email;

    public void ProcessNotifications(Notification model)
    {
        // Explanation: Encapsulates credit card specific logic
        Console.WriteLine($"Sending EMAIL to {model.Recipient}");
        Console.WriteLine($"Subject: {model.Subject}");
        Console.WriteLine($"Message: {model.Message}");
    }
}
