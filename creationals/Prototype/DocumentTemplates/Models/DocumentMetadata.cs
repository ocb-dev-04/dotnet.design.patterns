using Prototype.Abstractions;

namespace Prototype.DocumentTemplates.Models;

public class DocumentMetadata : IPrototype<DocumentMetadata>
{
    public Dictionary<string, string> Tags { get; set; }
    public string Version { get; set; }

    public DocumentMetadata()
    {
        Tags = new Dictionary<string, string>();
        Version = "1.0";
    }

    public DocumentMetadata Clone()
    {
        return new DocumentMetadata
        {
            Tags = new Dictionary<string, string>(this.Tags),
            Version = this.Version
        };
    }

    public DocumentMetadata DeepClone() => Clone();

    public override string ToString()
    {
        return $"Version {Version}, Tags: {Tags.Count}";
    }
}
