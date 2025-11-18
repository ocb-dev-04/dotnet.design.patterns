namespace Bridge.MessageSending.Abstractions;

// STEP 3: Abstraction
// Explanation: Defines high-level interface using implementor
public abstract class Message
{
    // Bridge: reference to implementor
    protected IMessageSender _sender;

    protected Message(IMessageSender sender)
    {
        _sender = sender;
    }

    // Abstract method to be implemented by refined abstractions
    public abstract void Send(string recipient, string content);

    // Can change implementor at runtime
    public void ChangeSender(IMessageSender sender)
    {
        Console.WriteLine($"[Bridge] Changing sender from {_sender.GetSenderType()} to {sender.GetSenderType()}");
        _sender = sender;
    }
}