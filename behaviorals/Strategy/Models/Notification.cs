using Strategy.Enums;

namespace Strategy.Models;

public sealed record Notification(
    NotificationType Type,
    string Recipient,
    string Subject,
    string Message
);