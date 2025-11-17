using Builder.EmailSender.Enums;
using Builder.EmailSender.Models;

namespace Builder.EmailSender.Builders;

// STEP 2: Builder
public class EmailBuilder
{
    private readonly Email _email;

    public EmailBuilder()
    {
        _email = new Email
        {
            To = new List<string>(),
            Cc = new List<string>(),
            Bcc = new List<string>(),
            Attachments = new List<EmailAttachment>(),
            Priority = EmailPriority.Normal,
            RequestReadReceipt = false
        };
    }

    public EmailBuilder From(string from)
    {
        _email.From = from;
        return this;
    }

    public EmailBuilder To(params string[] recipients)
    {
        _email.To.AddRange(recipients);
        return this;
    }

    public EmailBuilder Cc(params string[] recipients)
    {
        _email.Cc.AddRange(recipients);
        return this;
    }

    public EmailBuilder Bcc(params string[] recipients)
    {
        _email.Bcc.AddRange(recipients);
        return this;
    }

    public EmailBuilder WithSubject(string subject)
    {
        _email.Subject = subject;
        return this;
    }

    public EmailBuilder WithHtmlBody(string html)
    {
        _email.HtmlBody = html;
        return this;
    }

    public EmailBuilder WithTextBody(string text)
    {
        _email.TextBody = text;
        return this;
    }

    public EmailBuilder WithPriority(EmailPriority priority)
    {
        _email.Priority = priority;
        return this;
    }

    public EmailBuilder WithAttachment(string fileName, byte[] content, string contentType = "application/octet-stream")
    {
        _email.Attachments.Add(new EmailAttachment
        {
            FileName = fileName,
            Content = content,
            ContentType = contentType
        });
        return this;
    }

    public EmailBuilder RequestReadReceipt()
    {
        _email.RequestReadReceipt = true;
        return this;
    }

    public Email Build()
    {
        // Validation
        if (string.IsNullOrEmpty(_email.From))
            throw new InvalidOperationException("From address is required");

        if (!_email.To.Any())
            throw new InvalidOperationException("At least one recipient is required");

        if (string.IsNullOrEmpty(_email.Subject))
            throw new InvalidOperationException("Subject is required");

        if (string.IsNullOrEmpty(_email.HtmlBody) && string.IsNullOrEmpty(_email.TextBody))
            throw new InvalidOperationException("Email body is required");

        return _email;
    }
}