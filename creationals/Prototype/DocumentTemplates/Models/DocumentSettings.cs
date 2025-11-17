using Prototype.Abstractions;

namespace Prototype.DocumentTemplates.Models;

public class DocumentSettings : IPrototype<DocumentSettings>
{
    public string FontFamily { get; set; }
    public int FontSize { get; set; }
    public string PageSize { get; set; }
    public MarginSettings Margins { get; set; }

    public DocumentSettings()
    {
        FontFamily = "Arial";
        FontSize = 12;
        PageSize = "A4";
        Margins = new MarginSettings { Top = 1, Bottom = 1, Left = 1, Right = 1 };
    }

    public DocumentSettings Clone()
    {
        return new DocumentSettings
        {
            FontFamily = this.FontFamily,
            FontSize = this.FontSize,
            PageSize = this.PageSize,
            Margins = new MarginSettings
            {
                Top = this.Margins.Top,
                Bottom = this.Margins.Bottom,
                Left = this.Margins.Left,
                Right = this.Margins.Right
            }
        };
    }

    public DocumentSettings DeepClone() => Clone();

    public override string ToString()
    {
        return $"{FontFamily} {FontSize}pt, {PageSize}";
    }
}
