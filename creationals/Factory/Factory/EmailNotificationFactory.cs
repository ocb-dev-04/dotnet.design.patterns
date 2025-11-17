using Factory.Abstractions;
using Factory.Implementations;

namespace Factory.Factory;

// STEP 4: Concrete Creators
public class EmailNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}
