using Strategy.Enums;
using Strategy.Models;

namespace Strategy.Strategies;

// Explanation: Interface defines contract for all notification strategies
// This allows dependency injection and polymorphism
public interface INotificationStrategy
{
    NotificationType SupportedType { get; }
    void ProcessNotifications(Notification model);
}
