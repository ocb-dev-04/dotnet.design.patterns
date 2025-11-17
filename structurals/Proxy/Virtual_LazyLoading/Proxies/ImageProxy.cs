using Proxy.Virtual_LazyLoading.Abstractions;
using Proxy.Virtual_LazyLoading.Implementations;

namespace Proxy.Virtual_LazyLoading.Proxies;

// STEP 3: Proxy (Lazy Loading)
// Explanation: Controls access and creates real object only when needed
public class ImageProxy : IImage
{
    private readonly string _filename;
    private RealImage _realImage; // Real object (created on demand)

    public ImageProxy(string filename)
    {
        _filename = filename;
        // NOTE: RealImage is NOT created yet!
        Console.WriteLine($"[Proxy] Proxy created for: {_filename}");
    }

    public void Display()
    {
        // STEP 1: Create real object on first use (lazy loading)
        EnsureImageLoaded();

        // STEP 2: Delegate to real object
        _realImage.Display();
    }

    public string GetInfo()
    {
        // Can provide info without loading image
        if (_realImage is null)
            return $"Image: {_filename} (not loaded yet)";

        return _realImage.GetInfo();
    }

    private void EnsureImageLoaded()
    {
        // Explanation: Create real object only once, when needed
        if (_realImage is null)
        {
            Console.WriteLine($"[Proxy] Creating real image...");
            _realImage = new RealImage(_filename);
        }
    }
}
