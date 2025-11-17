using Strategy.Enums;
using Strategy.Models;

namespace Strategy.Services;

public sealed class WorseNotificationProcessor
{
    public void SendNotification(Notification notification)
    {
        if (notification.Type == NotificationType.Email)
        {
            Console.WriteLine($"Sending EMAIL to {notification.Recipient}");
            Console.WriteLine($"Subject: {notification.Subject}");
            Console.WriteLine($"Message: {notification.Message}");
        }
        else if (notification.Type == NotificationType.SMS)
        {
            Console.WriteLine($"Sending SMS to {notification.Recipient}");
            Console.WriteLine($"Message: {notification.Message}");
        }
        else if (notification.Type == NotificationType.Push)
        {
            Console.WriteLine($"Sending PUSH notification to device {notification.Recipient}");
            Console.WriteLine($"Title: {notification.Subject}");
            Console.WriteLine($"Body: {notification.Message}");
        }
        else if (notification.Type == NotificationType.Slack)
        {
            Console.WriteLine($"Posting to Slack channel {notification.Recipient}");
            Console.WriteLine($"Message: {notification.Subject} - {notification.Message}");
        }
        else
        {
            Console.WriteLine("Unsupported notification type");
        }
    }
}
