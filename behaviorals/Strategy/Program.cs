using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Strategy.Services;
using Strategy.Strategies;
using Strategy.Workers;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Step 1: Register all notification strategies
        // Explanation: Each strategy is registered as INotificationStrategy
        // The resolver will receive ALL of them through IEnumerable<INotificationStrategy>
        services.AddSingleton<INotificationStrategy, EmailStrategy>();
        services.AddSingleton<INotificationStrategy, SMSStrategy>();
        services.AddSingleton<INotificationStrategy, PushStrategy>();
        services.AddSingleton<INotificationStrategy, SlackStrategy>();

        // Step 2: Register strategy resolver
        // Explanation: Resolver automatically receives all registered strategies
        services.AddSingleton<StrategyResolver>();

        // Step 3: Register notification processor
        // Explanation: Processor receives resolver through constructor
        services.AddSingleton<NotificationProcessor>();

        // Step 4: Register hosted service (worker)
        // Explanation: Worker receives processor through constructor
        services.AddHostedService<NotificationWorker>();
    })
    .Build()
    .RunAsync();
