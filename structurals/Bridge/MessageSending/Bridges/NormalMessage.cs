using Bridge.MessageSending.Abstractions;

namespace Bridge.MessageSending.Bridges;

// STEP 4: Refined Abstractions
// Explanation: Extend abstraction with different behaviors
public class NormalMessage : Message
{
    public NormalMessage(IMessageSender sender) : base(sender) { }

    public override void Send(string recipient, string content)
    {
        Console.WriteLine("\n─────────────────────────────────────────");
        Console.WriteLine("         📧 Normal Message");
        Console.WriteLine("─────────────────────────────────────────");

        // Send normally
        _sender.SendMessage(recipient, content);
    }
}
