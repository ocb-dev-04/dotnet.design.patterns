using Strategy.Enums;
using Strategy.Strategies.Abstractions;

namespace Strategy.Services;

// Explanation: This class resolves which strategy to use based on notification type
// Uses constructor injection to receive all available strategies
public sealed class StrategyResolver
{
    private readonly IEnumerable<INotificationStrategy> _notificationStrategies;

    // Step 1: Constructor injection receives all registered strategies
    // Explanation: .NET DI container automatically injects all INotificationStrategy implementations
    public StrategyResolver(IEnumerable<INotificationStrategy> instances)
        => _notificationStrategies = instances ?? throw new ArgumentNullException(nameof(instances));

    public INotificationStrategy Resolve(NotificationType notificationType)
    {
        // Step 2: Resolve strategy based on notification type
        // Explanation: LINQ finds the strategy that matches the notification type
        INotificationStrategy? found = _notificationStrategies.FirstOrDefault(f => f.SupportedType.Equals(notificationType));
        if (found is null)
            throw new NullReferenceException("Unsupported notification type");

        return found;
    }
}
