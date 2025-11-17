namespace Proxy.Virtual_LazyLoading.Abstractions;

// STEP 1: Subject Interface
// Explanation: Common interface for real object and proxy
public interface IImage
{
    void Display();
    string GetInfo();
}