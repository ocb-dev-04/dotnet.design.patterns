using Builder.EmailSender.Builders;
using Builder.EmailSender.Enums;

namespace Builder.EmailSender;

public sealed class EmailEntry
{
    public static void SendEmails()
    {
        // Example 1: Simple email
        var email1 = new EmailBuilder()
            .From("sender@example.com")
            .To("recipient@example.com")
            .WithSubject("Welcome!")
            .WithHtmlBody("<h1>Welcome to our platform!</h1><p>We're glad to have you.</p>")
            .Build();

        Console.WriteLine(email1);
        Console.WriteLine();

        // Example 2: Email with attachments and high priority
        var email2 = new EmailBuilder()
            .From("admin@company.com")
            .To("employee1@company.com", "employee2@company.com")
            .Cc("manager@company.com")
            .WithSubject("Urgent: Q4 Report")
            .WithHtmlBody("<p>Please review the attached Q4 report immediately.</p>")
            .WithPriority(EmailPriority.Urgent)
            .WithAttachment("Q4_Report.pdf", new byte[1024], "application/pdf")
            .WithAttachment("Budget.xlsx", new byte[2048], "application/vnd.ms-excel")
            .RequestReadReceipt()
            .Build();

        Console.WriteLine(email2);
        Console.WriteLine();

        // Example 3: Newsletter with multiple recipients
        var email3 = new EmailBuilder()
            .From("newsletter@company.com")
            .To("subscriber1@example.com", "subscriber2@example.com", "subscriber3@example.com")
            .WithSubject("Monthly Newsletter - January 2024")
            .WithHtmlBody("<h2>This Month's Highlights</h2><p>Check out what's new...</p>")
            .WithTextBody("This Month's Highlights\n\nCheck out what's new...")
            .WithPriority(EmailPriority.Low)
            .Build();

        Console.WriteLine(email3);
    }
}

// OUTPUT:
/*
=== Email ===
From: sender@example.com
To: recipient@example.com
Subject: Welcome!
Priority: Normal
HTML Body: <h1>Welcome to our platform!</h1><p>We're glad...
Read Receipt: False

=== Email ===
From: admin@company.com
To: employee1@company.com, employee2@company.com
Cc: manager@company.com
Subject: Urgent: Q4 Report
Priority: Urgent
HTML Body: <p>Please review the attached Q4 report immediat...
Attachments: Q4_Report.pdf, Budget.xlsx
Read Receipt: True

=== Email ===
From: newsletter@company.com
To: subscriber1@example.com, subscriber2@example.com, subscriber3@example.com
Subject: Monthly Newsletter - January 2024
Priority: Low
HTML Body: <h2>This Month's Highlights</h2><p>Check out wh...
Text Body: This Month's Highlights\n\nCheck out what's new...
Read Receipt: False
*/