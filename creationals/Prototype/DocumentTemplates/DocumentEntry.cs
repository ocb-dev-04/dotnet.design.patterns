using Prototype.DocumentTemplates.Registry;
using Prototype.DocumentTemplates.Implementations;

namespace Prototype.DocumentTemplates;

public sealed class DocumentEntry
{
    public static void Run()
    {
        DocumentTemplateRegistry registry = new ();

        registry.ListTemplates();

        // Example 1: Create report from template
        Console.WriteLine("=== Creating Report ===\n");

        Document report1 = registry.CreateDocument("report");
        report1.Title = "Q1 2024 Financial Report";
        report1.Author = "John Doe";
        report1.Sections[0].Content = "Q1 showed strong growth...";

        Console.WriteLine(report1);

        // Example 2: Create another report (independent copy)
        Console.WriteLine("=== Creating Another Report ===\n");

        Document report2 = registry.CreateDocument("report");
        report2.Title = "Q2 2024 Financial Report";
        report2.Author = "Jane Smith";
        report2.Sections[0].Content = "Q2 exceeded expectations...";

        Console.WriteLine(report2);

        // Verify independence
        Console.WriteLine("=== Verifying Independence ===\n");
        Console.WriteLine($"Report1 Title: {report1.Title}");
        Console.WriteLine($"Report2 Title: {report2.Title}");
        Console.WriteLine($"Report1 Content: {report1.Sections[0].Content}");
        Console.WriteLine($"Report2 Content: {report2.Sections[0].Content}");
        Console.WriteLine($"Are different objects: {!ReferenceEquals(report1, report2)}");

        // Example 3: Create invoice
        Console.WriteLine("\n=== Creating Invoice ===\n");

        Document invoice = registry.CreateDocument("invoice");
        invoice.Title = "Invoice #12345";
        invoice.Author = "Accounting Team";
        invoice.Sections[1].Content = "1. Product A - $100\n2. Product B - $200";

        Console.WriteLine(invoice);
    }
}

// OUTPUT:
/*
[Registry] Initialized 3 templates

=== Available Templates ===
- report: Monthly Report
- invoice: Invoice
- letter: Business Letter

=== Creating Report ===

[Registry] Creating document from 'report' template
[Prototype] Creating deep clone...
=== Document: Q1 2024 Financial Report ===
Author: John Doe
Created: 2024-01-15
Sections: 3
Metadata: Version 1.0, Tags: 2
Settings: Times New Roman 11pt, A4

=== Creating Another Report ===

[Registry] Creating document from 'report' template
[Prototype] Creating deep clone...
=== Document: Q2 2024 Financial Report ===
Author: Jane Smith
Created: 2024-01-15
Sections: 3
Metadata: Version 1.0, Tags: 2
Settings: Times New Roman 11pt, A4

=== Verifying Independence ===

Report1 Title: Q1 2024 Financial Report
Report2 Title: Q2 2024 Financial Report
Report1 Content: Q1 showed strong growth...
Report2 Content: Q2 exceeded expectations...
Are different objects: True

=== Creating Invoice ===

[Registry] Creating document from 'invoice' template
[Prototype] Creating deep clone...
=== Document: Invoice #12345 ===
Author: Accounting Team
Created: 2024-01-15
Sections: 3
Metadata: Version 1.0, Tags: 2
Settings: Arial 10pt, A4
*/