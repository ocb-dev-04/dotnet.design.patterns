namespace Proxy.Protection_AccessControl.Model;

public class User
{
    public string Name { get; set; }
    public string Role { get; set; }
    public List<string> Permissions { get; set; } = new();
}
