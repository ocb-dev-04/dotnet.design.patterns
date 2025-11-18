using Bridge.MessageSending.Abstractions;
using Bridge.MessageSending.Bridges;
using Bridge.MessageSending.Implementations;

namespace Bridge.MessageSending;

// PROBLEM: Without Bridge pattern, you'd need:
// EmailUrgentMessage, EmailNormalMessage, EmailLowPriorityMessage
// SmsUrgentMessage, SmsNormalMessage, SmsLowPriorityMessage
// PushUrgentMessage, PushNormalMessage, PushLowPriorityMessage
// = 9 classes! Bridge reduces this to 3 + 3 = 6

public sealed class NotificationSystem
{
    public static void SendNotifications()
    {
        // Example 1: Urgent message via Email
        Console.WriteLine("=== Example 1: Urgent Email ===");

        IMessageSender emailSender = new EmailSender();
        Message urgentEmail = new UrgentMessage(emailSender);
        urgentEmail.Send("admin@company.com", "Server is down!");

        // Example 2: Normal message via SMS
        Console.WriteLine("\n=== Example 2: Normal SMS ===");

        IMessageSender smsSender = new SmsSender();
        Message normalSms = new NormalMessage(smsSender);
        normalSms.Send("1234567890", "Your order has shipped");

        // Example 3: Low priority via Push
        Console.WriteLine("\n=== Example 3: Low Priority Push ===");

        IMessageSender pushSender = new PushNotificationSender();
        Message lowPriorityPush = new LowPriorityMessage(pushSender);
        lowPriorityPush.Send("device-token-123", "Check out our new features");

        // Example 4: Change sender at runtime (Bridge advantage!)
        Console.WriteLine("\n=== Example 4: Changing Sender ===");

        Message flexibleMessage = new UrgentMessage(emailSender);
        flexibleMessage.Send("user@example.com", "Payment failed");

        // Switch from email to SMS
        flexibleMessage.ChangeSender(smsSender);
        flexibleMessage.Send("1234567890", "Payment failed");

        // Example 5: Mix and match any combination
        Console.WriteLine("\n=== Example 5: All Combinations ===");

        (Message, string, string)[] combinations = new (Message, string, string)[]
        {
            (new UrgentMessage(emailSender), "urgent@example.com", "Urgent via Email"),
            (new UrgentMessage(smsSender), "555-0100", "Urgent via SMS"),
            (new NormalMessage(pushSender), "device-001", "Normal via Push"),
            (new LowPriorityMessage(emailSender), "updates@example.com", "Low Priority via Email")
        };

        foreach (var (message, recipient, description) in combinations)
        {
            Console.WriteLine($"\n--- {description} ---");
            message.Send(recipient, "Test message");
        }
    }
}

// OUTPUT:
/*
=== Example 1: Urgent Email ===

╔════════════════════════════════════════╗
║         🚨 URGENT MESSAGE 🚨           ║
╚════════════════════════════════════════╝
[Email] To: admin@company.com
[Email] Body: [URGENT] Server is down!
[Email] ✓ Email sent via SMTP
[Urgent] Sending confirmation...
[Email] To: admin@company.com
[Email] Body: Please confirm receipt of urgent message.
[Email] ✓ Email sent via SMTP

=== Example 2: Normal SMS ===

─────────────────────────────────────────
         📧 Normal Message
─────────────────────────────────────────
[SMS] To: 1234567890
[SMS] Text: Your order has shipped
[SMS] ✓ SMS sent via Twilio

=== Example 3: Low Priority Push ===

┌────────────────────────────────────────┐
│      📝 Low Priority Message           │
└────────────────────────────────────────┘
[LowPriority] Queuing message for batch send...
[Push] Device: device-token-123
[Push] Notification: [Low Priority] Check out our new features
[Push] ✓ Push sent via FCM

=== Example 4: Changing Sender ===

╔════════════════════════════════════════╗
║         🚨 URGENT MESSAGE 🚨           ║
╚════════════════════════════════════════╝
[Email] To: user@example.com
[Email] Body: [URGENT] Payment failed
[Email] ✓ Email sent via SMTP
[Urgent] Sending confirmation...
[Email] To: user@example.com
[Email] Body: Please confirm receipt of urgent message.
[Email] ✓ Email sent via SMTP
[Bridge] Changing sender from Email to SMS

╔════════════════════════════════════════╗
║         🚨 URGENT MESSAGE 🚨           ║
╚════════════════════════════════════════╝
[SMS] To: 1234567890
[SMS] Text: [URGENT] Payment failed
[SMS] ✓ SMS sent via Twilio
[Urgent] Sending confirmation...
[SMS] To: 1234567890
[SMS] Text: Please confirm receipt of urgent message.
[SMS] ✓ SMS sent via Twilio
*/