using Builder.ApiClient.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.ApiClient;

public sealed class ApiClient
{
    public static void MakeRequests()
    {
        // Example 1: Simple GET request
        Console.WriteLine("=== Example 1: Simple GET ===\n");

        var request1 = new HttpRequestBuilder("https://api.example.com/users", "GET")
            .AddQueryParameter("page", "1")
            .AddQueryParameter("limit", "10")
            .WithBearerToken("abc123xyz")
            .Build();

        Console.WriteLine(request1);

        // Example 2: POST with JSON body
        Console.WriteLine("\n=== Example 2: POST with JSON ===\n");

        var userData = new { Name = "John Doe", Email = "john@example.com", Age = 30 };

        var request2 = new HttpRequestBuilder("https://api.example.com/users", "POST")
            .WithJsonBody(userData)
            .WithBearerToken("abc123xyz")
            .AddHeader("X-Request-ID", Guid.NewGuid().ToString())
            .WithTimeout(60)
            .Build();

        Console.WriteLine(request2);

        // Example 3: Complex request with many options
        Console.WriteLine("\n=== Example 3: Complex Request ===\n");

        var request3 = new HttpRequestBuilder("https://api.example.com/search", "GET")
            .AddQueryParameter("q", "dotnet patterns")
            .AddQueryParameter("category", "books")
            .AddQueryParameter("sort", "relevance")
            .AddHeader("Accept", "application/json")
            .AddHeader("Accept-Language", "en-US")
            .AddHeader("User-Agent", "MyApp/1.0")
            .WithTimeout(45)
            .FollowRedirects(false)
            .Build();

        Console.WriteLine(request3);
    }
}

// OUTPUT:
/*
=== Example 1: Simple GET ===

=== HTTP Request ===
Method: GET
URL: https://api.example.com/users?page=1&limit=10
Query Parameters:
  page = 1
  limit = 10
Headers:
  Authorization: Bearer abc123xyz
  Content-Type: application/json
Timeout: 30s
Follow Redirects: True

=== Example 2: POST with JSON ===

=== HTTP Request ===
Method: POST
URL: https://api.example.com/users
Headers:
  Authorization: Bearer abc123xyz
  X-Request-ID: 12345678-1234-1234-1234-123456789012
  Content-Type: application/json
Body: {"Name":"John Doe","Email":"john@example.com","Age":30}
Timeout: 60s
Follow Redirects: True

=== Example 3: Complex Request ===

=== HTTP Request ===
Method: GET
URL: https://api.example.com/search?q=dotnet+patterns&category=books&sort=relevance
Query Parameters:
  q = dotnet patterns
  category = books
  sort = relevance
Headers:
  Accept: application/json
  Accept-Language: en-US
  User-Agent: MyApp/1.0
  Content-Type: application/json
Timeout: 45s
Follow Redirects: False
*/