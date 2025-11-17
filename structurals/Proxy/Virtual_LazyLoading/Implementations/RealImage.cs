using Proxy.Virtual_LazyLoading.Abstractions;

namespace Proxy.Virtual_LazyLoading.Implementations;

// STEP 2: Real Subject (Heavy Object)
// Explanation: Expensive object that we want to delay creating
public class RealImage : IImage
{
    private readonly string _filename;
    private byte[] _imageData;

    public RealImage(string filename)
    {
        _filename = filename;
        // STEP 1: Simulate expensive loading operation
        LoadImageFromDisk();
    }

    private void LoadImageFromDisk()
    {
        // Explanation: Expensive operation - loading large file
        Console.WriteLine($"[RealImage] Loading image from disk: {_filename}");
        Thread.Sleep(2000); // Simulate slow I/O
        _imageData = new byte[1024 * 1024]; // 1 MB image
        Console.WriteLine($"[RealImage] Image loaded: {_filename}");
    }

    public void Display()
    {
        Console.WriteLine($"[RealImage] Displaying image: {_filename}");
    }

    public string GetInfo()
    {
        return $"Image: {_filename}, Size: {_imageData.Length} bytes";
    }
}