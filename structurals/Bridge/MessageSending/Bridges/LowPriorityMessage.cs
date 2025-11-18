using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Bridges;

// STEP 4: Refined Abstractions
// Explanation: Extend abstraction with different behaviors
public class LowPriorityMessage : Message
{
    public LowPriorityMessage(IMessageSender sender) : base(sender) { }

    public override void Send(string recipient, string content)
    {
        Console.WriteLine("\n┌────────────────────────────────────────┐");
        Console.WriteLine("│      📝 Low Priority Message           │");
        Console.WriteLine("└────────────────────────────────────────┘");

        // Add low priority tag
        string taggedContent = $"[Low Priority] {content}";

        // Might batch or delay sending
        Console.WriteLine("[LowPriority] Queuing message for batch send...");
        _sender.SendMessage(recipient, taggedContent);
    }
}