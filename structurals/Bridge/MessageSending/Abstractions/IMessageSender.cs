namespace Bridge.MessageSending.Abstractions;

// STEP 1: Implementor Interface
// Explanation: Defines interface for implementation classes
public interface IMessageSender
{
    void SendMessage(string recipient, string message);
    string GetSenderType();
}
