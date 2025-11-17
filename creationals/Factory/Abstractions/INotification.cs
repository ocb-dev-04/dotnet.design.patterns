namespace Factory.Abstractions;

// STEP 1: Product Interface
public interface INotification
{
    Task SendAsync(string recipient, string message);
    string GetChannelType();
}
