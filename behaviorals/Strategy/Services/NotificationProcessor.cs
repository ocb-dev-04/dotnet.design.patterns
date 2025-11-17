using Strategy.Models;
using Strategy.Strategies;

namespace Strategy.Services;

// Explanation: NotificationProcessor now uses dependency injection
// No more if-else chains, delegates to strategy resolver
public sealed class NotificationProcessor
{
    private readonly StrategyResolver _strategyResolver;

    // Step 1: Constructor injection for resolver
    // Explanation: Receives resolver through DI container
    public NotificationProcessor(StrategyResolver strategyResolver)
        => _strategyResolver = strategyResolver ?? throw new ArgumentNullException(nameof(strategyResolver));

    // Step 2: Process notification using resolved strategy
    // Explanation: No conditional logic here, just delegation
    public void SendNotification(Notification notification)
    {
        // Get appropriate strategy
        INotificationStrategy instance = _strategyResolver.Resolve(notification.Type);

        // Execute strategy
        instance.ProcessNotifications(notification);
    }
}
