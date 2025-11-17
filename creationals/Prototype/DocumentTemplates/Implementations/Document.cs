using Prototype.Abstractions;
using Prototype.DocumentTemplates.Models;
using System.Text;

namespace Prototype.DocumentTemplates.Implementations;


// STEP 2: Complex Product with Prototype
public class Document : IPrototype<Document>
{
    // Simple properties
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDate { get; set; }

    // Complex properties (reference types)
    public DocumentMetadata Metadata { get; set; }
    public List<DocumentSection> Sections { get; set; }
    public DocumentSettings Settings { get; set; }

    public Document()
    {
        CreatedDate = DateTime.Now;
        Sections = new List<DocumentSection>();
        Metadata = new DocumentMetadata();
        Settings = new DocumentSettings();
    }

    // Shallow Clone - copies references
    public Document Clone()
    {
        Console.WriteLine("[Prototype] Creating shallow clone...");

        // MemberwiseClone creates shallow copy
        return (Document)this.MemberwiseClone();
    }

    // Deep Clone - copies objects recursively
    public Document DeepClone()
    {
        Console.WriteLine("[Prototype] Creating deep clone...");

        var clone = new Document
        {
            Title = this.Title,
            Author = this.Author,
            CreatedDate = this.CreatedDate,

            // Deep copy of complex objects
            Metadata = this.Metadata.Clone(),
            Settings = this.Settings.Clone(),

            // Deep copy of list
            Sections = this.Sections.Select(s => s.Clone()).ToList()
        };

        return clone;
    }

    public override string ToString()
    {
        StringBuilder sb = new ();
        sb.AppendLine($"=== Document: {Title} ===");
        sb.AppendLine($"Author: {Author}");
        sb.AppendLine($"Created: {CreatedDate:yyyy-MM-dd}");
        sb.AppendLine($"Sections: {Sections.Count}");
        sb.AppendLine($"Metadata: {Metadata}");
        sb.AppendLine($"Settings: {Settings}");
        return sb.ToString();
    }
}