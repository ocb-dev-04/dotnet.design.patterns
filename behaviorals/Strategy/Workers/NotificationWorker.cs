using Strategy.Enums;
using Strategy.Models;
using Strategy.Services;
using Microsoft.Extensions.Hosting;

namespace Strategy.Workers;

internal class NotificationWorker : BackgroundService
{
    private readonly NotificationProcessor _notificationProcessor;

    // Step 1: Constructor injection for NotificationProcessor
    // Explanation: No more 'new' keyword, DI container handles creation
    public NotificationWorker(NotificationProcessor notificationProcessor)
        => _notificationProcessor = notificationProcessor ?? throw new ArgumentNullException(nameof(notificationProcessor));

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Notification notification = CreateEmailNotification();

        // Step 2: Use injected processor
        // Explanation: All dependencies are managed by DI container
        _notificationProcessor.SendNotification(notification);

        return Task.CompletedTask;
    }

    private Notification CreateEmailNotification()
        => new Notification(
            NotificationType.Email,
            "user@example.com",
            "Welcome",
            "Welcome to our platform!"
        );
}
