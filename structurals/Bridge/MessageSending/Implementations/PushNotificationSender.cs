using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Implementations;

// STEP 2: Concrete Implementors
// Explanation: Different ways to send messages
public class PushNotificationSender : IMessageSender
{
    public void SendMessage(string recipient, string message)
    {
        Console.WriteLine($"[Push] Device: {recipient}");
        Console.WriteLine($"[Push] Notification: {message}");
        Console.WriteLine("[Push] ✓ Push sent via FCM");
    }

    public string GetSenderType() => "Push Notification";
}