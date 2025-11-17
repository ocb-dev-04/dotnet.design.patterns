using Builder.ApiClient.Models;

namespace Builder.ApiClient.Builders;

// STEP 2: Builder
// Explanation: Provides fluent API for building HttpRequest
public class HttpRequestBuilder
{
    private readonly HttpRequest _request;

    public HttpRequestBuilder(string url, string method = "GET")
    {
        // Step 1: Initialize with required parameters
        _request = new HttpRequest
        {
            Url = url,
            Method = method,
            Headers = new Dictionary<string, string>(),
            QueryParameters = new Dictionary<string, string>(),
            TimeoutSeconds = 30, // default
            FollowRedirects = true, // default
            ContentType = "application/json" // default
        };
    }

    // Step 2: Methods return 'this' for chaining (fluent interface)

    public HttpRequestBuilder AddHeader(string key, string value)
    {
        _request.Headers[key] = value;
        return this;
    }

    public HttpRequestBuilder AddQueryParameter(string key, string value)
    {
        _request.QueryParameters[key] = value;
        return this;
    }

    public HttpRequestBuilder WithBody(string body)
    {
        _request.Body = body;
        return this;
    }

    public HttpRequestBuilder WithJsonBody(object obj)
    {
        _request.Body = System.Text.Json.JsonSerializer.Serialize(obj);
        _request.ContentType = "application/json";
        return this;
    }

    public HttpRequestBuilder WithTimeout(int seconds)
    {
        _request.TimeoutSeconds = seconds;
        return this;
    }

    public HttpRequestBuilder WithContentType(string contentType)
    {
        _request.ContentType = contentType;
        return this;
    }

    public HttpRequestBuilder FollowRedirects(bool follow = true)
    {
        _request.FollowRedirects = follow;
        return this;
    }

    public HttpRequestBuilder WithBearerToken(string token)
    {
        _request.Headers["Authorization"] = $"Bearer {token}";
        return this;
    }

    // Step 3: Build final object
    public HttpRequest Build()
    {
        // Could add validation here
        if (string.IsNullOrEmpty(_request.Url))
            throw new InvalidOperationException("URL is required");

        // Append query parameters to URL
        if (_request.QueryParameters.Any())
        {
            string? queryString = string.Join("&",
                _request.QueryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            _request.Url = $"{_request.Url}?{queryString}";
        }

        // Set Content-Type header
        if (!string.IsNullOrEmpty(_request.ContentType))
            _request.Headers["Content-Type"] = _request.ContentType;

        return _request;
    }
}
