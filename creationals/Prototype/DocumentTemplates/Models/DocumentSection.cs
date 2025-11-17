using Prototype.Abstractions;

namespace Prototype.DocumentTemplates.Models;

public class DocumentSection : IPrototype<DocumentSection>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int PageNumber { get; set; }

    public DocumentSection Clone()
    {
        return new DocumentSection
        {
            Title = this.Title,
            Content = this.Content,
            PageNumber = this.PageNumber
        };
    }

    public DocumentSection DeepClone() => Clone();
}
