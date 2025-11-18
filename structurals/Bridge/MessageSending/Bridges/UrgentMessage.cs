using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Bridges;


// STEP 4: Refined Abstractions
// Explanation: Extend abstraction with different behaviors
public class UrgentMessage : Message
{
    public UrgentMessage(IMessageSender sender) : base(sender) { }

    public override void Send(string recipient, string content)
    {
        Console.WriteLine("\n╔════════════════════════════════════════╗");
        Console.WriteLine("║         🚨 URGENT MESSAGE 🚨           ║");
        Console.WriteLine("╚════════════════════════════════════════╝");

        // Add urgent prefix
        string urgentContent = $"[URGENT] {content}";

        // Use the bridge to send
        _sender.SendMessage(recipient, urgentContent);

        // Urgent messages might send multiple times
        Console.WriteLine("[Urgent] Sending confirmation...");
        _sender.SendMessage(recipient, "Please confirm receipt of urgent message.");
    }
}
