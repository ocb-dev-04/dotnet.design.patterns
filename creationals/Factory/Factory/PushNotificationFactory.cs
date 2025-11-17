using Factory.Abstractions;
using Factory.Implementations;

namespace Factory.Factory;

// STEP 4: Concrete Creators
public class PushNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}