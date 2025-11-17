using Builder.EmailSender.Enums;
using System.Text;

namespace Builder.EmailSender.Models;

// STEP 1: Product
public class Email
{
    public List<string> To { get; set; }
    public List<string> Cc { get; set; }
    public List<string> Bcc { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string HtmlBody { get; set; }
    public string TextBody { get; set; }
    public List<EmailAttachment> Attachments { get; set; }
    public EmailPriority Priority { get; set; }
    public bool RequestReadReceipt { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("=== Email ===");
        sb.AppendLine($"From: {From}");
        sb.AppendLine($"To: {string.Join(", ", To)}");

        if (Cc?.Any() == true)
            sb.AppendLine($"Cc: {string.Join(", ", Cc)}");

        if (Bcc?.Any() == true)
            sb.AppendLine($"Bcc: {string.Join(", ", Bcc)}");

        sb.AppendLine($"Subject: {Subject}");
        sb.AppendLine($"Priority: {Priority}");

        if (!string.IsNullOrEmpty(HtmlBody))
            sb.AppendLine($"HTML Body: {HtmlBody.Substring(0, Math.Min(50, HtmlBody.Length))}...");

        if (!string.IsNullOrEmpty(TextBody))
            sb.AppendLine($"Text Body: {TextBody.Substring(0, Math.Min(50, TextBody.Length))}...");

        if (Attachments?.Any() == true)
            sb.AppendLine($"Attachments: {string.Join(", ", Attachments.Select(a => a.FileName))}");

        sb.AppendLine($"Read Receipt: {RequestReadReceipt}");

        return sb.ToString();
    }
}

public class EmailAttachment
{
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    public string ContentType { get; set; }
}
