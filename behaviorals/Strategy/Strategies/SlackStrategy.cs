using Strategy.Enums;
using Strategy.Models;
using Strategy.Strategies.Abstractions;

namespace Strategy.Strategies;

public sealed class SlackStrategy : INotificationStrategy
{
    // Explanation: Each strategy knows which type it handles
    public NotificationType SupportedType => NotificationType.Slack;

    public void ProcessNotifications(Notification model)
    {
        // Explanation: Encapsulates credit card specific logic
        Console.WriteLine($"Posting to Slack channel {model.Recipient}");
        Console.WriteLine($"Message: {model.Subject} - {model.Message}");
    }
}