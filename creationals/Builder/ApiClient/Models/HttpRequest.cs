using System.Text;

namespace Builder.ApiClient.Models;

// STEP 1: Complex Product
// Explanation: Object with many optional parameters
public class HttpRequest
{
    // Required
    public string Url { get; set; }
    public string Method { get; set; }

    // Optional
    public Dictionary<string, string> Headers { get; set; }
    public Dictionary<string, string> QueryParameters { get; set; }
    public string Body { get; set; }
    public int TimeoutSeconds { get; set; }
    public bool FollowRedirects { get; set; }
    public string ContentType { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== HTTP Request ===");
        sb.AppendLine($"Method: {Method}");
        sb.AppendLine($"URL: {Url}");

        if (QueryParameters?.Any() == true)
        {
            sb.AppendLine("Query Parameters:");
            foreach (var param in QueryParameters)
            {
                sb.AppendLine($"  {param.Key} = {param.Value}");
            }
        }

        if (Headers?.Any() == true)
        {
            sb.AppendLine("Headers:");
            foreach (var header in Headers)
            {
                sb.AppendLine($"  {header.Key}: {header.Value}");
            }
        }

        if (!string.IsNullOrEmpty(Body))
        {
            sb.AppendLine($"Body: {Body}");
        }

        sb.AppendLine($"Timeout: {TimeoutSeconds}s");
        sb.AppendLine($"Follow Redirects: {FollowRedirects}");

        return sb.ToString();
    }
}