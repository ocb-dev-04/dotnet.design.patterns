using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Implementations;

// STEP 2: Concrete Implementors
// Explanation: Different ways to send messages
public class SmsSender : IMessageSender
{
    public void SendMessage(string recipient, string message)
    {
        Console.WriteLine($"[SMS] To: {recipient}");
        Console.WriteLine($"[SMS] Text: {message}");
        Console.WriteLine("[SMS] ✓ SMS sent via Twilio");
    }

    public string GetSenderType() => "SMS";
}
