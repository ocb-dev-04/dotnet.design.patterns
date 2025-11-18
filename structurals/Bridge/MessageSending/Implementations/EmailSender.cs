using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Implementations;

// STEP 2: Concrete Implementors
// Explanation: Different ways to send messages
public class EmailSender : IMessageSender
{
    public void SendMessage(string recipient, string message)
    {
        Console.WriteLine($"[Email] To: {recipient}");
        Console.WriteLine($"[Email] Body: {message}");
        Console.WriteLine("[Email] ✓ Email sent via SMTP");
    }

    public string GetSenderType() => "Email";
}
