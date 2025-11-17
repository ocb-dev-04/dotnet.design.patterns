using Proxy.Virtual_LazyLoading.Abstractions;
using Proxy.Virtual_LazyLoading.Proxies;

namespace Proxy.Virtual_LazyLoading;

public sealed class VirtualEntry
{
    public static void Start()
    {
        // STEP 1: Create proxies (fast, no heavy loading)
        Console.WriteLine("Creating image proxies...\n");

        IImage image1 = new ImageProxy("photo1.jpg");
        IImage image2 = new ImageProxy("photo2.jpg");
        IImage image3 = new ImageProxy("photo3.jpg");

        Console.WriteLine("\nProxies created instantly!\n");

        // STEP 2: Get info without loading images
        Console.WriteLine(image1.GetInfo());
        Console.WriteLine(image2.GetInfo());
        Console.WriteLine(image3.GetInfo());

        // STEP 3: Display first image (triggers loading)
        Console.WriteLine("\nDisplaying first image...");
        image1.Display(); // Real image loaded here!

        // STEP 4: Display same image again (already loaded)
        Console.WriteLine("\nDisplaying first image again...");
        image1.Display(); // No loading, uses existing instance

        // STEP 5: Display second image
        Console.WriteLine("\nDisplaying second image...");
        image2.Display(); // Real image loaded here!

    }
}

// OUTPUT:
/*
Creating image proxies...

[Proxy] Proxy created for: photo1.jpg
[Proxy] Proxy created for: photo2.jpg
[Proxy] Proxy created for: photo3.jpg

Proxies created instantly!

Image: photo1.jpg (not loaded yet)
Image: photo2.jpg (not loaded yet)
Image: photo3.jpg (not loaded yet)

Displaying first image...
[Proxy] Creating real image...
[RealImage] Loading image from disk: photo1.jpg
[RealImage] Image loaded: photo1.jpg
[RealImage] Displaying image: photo1.jpg

Displaying first image again...
[RealImage] Displaying image: photo1.jpg

Displaying second image...
[Proxy] Creating real image...
[RealImage] Loading image from disk: photo2.jpg
[RealImage] Image loaded: photo2.jpg
[RealImage] Displaying image: photo2.jpg
*/