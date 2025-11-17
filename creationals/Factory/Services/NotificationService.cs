using Factory.Factory;

namespace Factory.Services;

// STEP 5: Factory Selector
public class NotificationService
{
    private readonly Dictionary<string, NotificationFactory> _factories;

    public NotificationService()
    {
        _factories = new Dictionary<string, NotificationFactory>
        {
            { "email", new EmailNotificationFactory() },
            { "sms", new SmsNotificationFactory() },
            { "push", new PushNotificationFactory() }
        };
    }

    public async Task SendNotification(string type, string recipient, string message)
    {
        if (!_factories.TryGetValue(type.ToLower(), out var factory))
            throw new ArgumentException($"Unknown type: {type}");

        await factory.NotifyUser(recipient, message);
    }
}