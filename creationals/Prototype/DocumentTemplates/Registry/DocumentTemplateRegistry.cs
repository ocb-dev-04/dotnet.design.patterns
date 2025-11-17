using Prototype.DocumentTemplates.Implementations;
using Prototype.DocumentTemplates.Models;

namespace Prototype.DocumentTemplates.Registry;

// STEP 3: Document Template Registry
// Explanation: Stores prototypes and creates copies
public class DocumentTemplateRegistry
{
    private readonly Dictionary<string, Document> _templates;

    public DocumentTemplateRegistry()
    {
        _templates = new Dictionary<string, Document>();
        InitializeTemplates();
    }

    private void InitializeTemplates()
    {
        // Step 1: Create Report Template
        var reportTemplate = new Document
        {
            Title = "Monthly Report",
            Author = "System",
        };
        reportTemplate.Sections.Add(new DocumentSection
        {
            Title = "Executive Summary",
            Content = "[Executive summary goes here]",
            PageNumber = 1
        });
        reportTemplate.Sections.Add(new DocumentSection
        {
            Title = "Financial Data",
            Content = "[Financial data goes here]",
            PageNumber = 2
        });
        reportTemplate.Sections.Add(new DocumentSection
        {
            Title = "Conclusions",
            Content = "[Conclusions go here]",
            PageNumber = 3
        });
        reportTemplate.Metadata.Tags["Type"] = "Report";
        reportTemplate.Metadata.Tags["Department"] = "Finance";
        reportTemplate.Settings.FontFamily = "Times New Roman";
        reportTemplate.Settings.FontSize = 11;

        // Step 2: Create Invoice Template
        var invoiceTemplate = new Document
        {
            Title = "Invoice",
            Author = "Accounting",
        };
        invoiceTemplate.Sections.Add(new DocumentSection
        {
            Title = "Invoice Details",
            Content = "[Invoice number, date, etc.]",
            PageNumber = 1
        });
        invoiceTemplate.Sections.Add(new DocumentSection
        {
            Title = "Line Items",
            Content = "[Product list and prices]",
            PageNumber = 1
        });
        invoiceTemplate.Sections.Add(new DocumentSection
        {
            Title = "Payment Terms",
            Content = "[Payment terms and conditions]",
            PageNumber = 2
        });
        invoiceTemplate.Metadata.Tags["Type"] = "Invoice";
        invoiceTemplate.Metadata.Tags["Department"] = "Sales";
        invoiceTemplate.Settings.FontFamily = "Arial";
        invoiceTemplate.Settings.FontSize = 10;

        // Step 3: Create Letter Template
        var letterTemplate = new Document
        {
            Title = "Business Letter",
            Author = "HR",
        };
        letterTemplate.Sections.Add(new DocumentSection
        {
            Title = "Header",
            Content = "[Company letterhead]",
            PageNumber = 1
        });
        letterTemplate.Sections.Add(new DocumentSection
        {
            Title = "Body",
            Content = "[Letter content]",
            PageNumber = 1
        });
        letterTemplate.Sections.Add(new DocumentSection
        {
            Title = "Footer",
            Content = "[Signature and contact info]",
            PageNumber = 1
        });
        letterTemplate.Metadata.Tags["Type"] = "Letter";
        letterTemplate.Metadata.Tags["Department"] = "HR";

        // Step 4: Register templates
        _templates["report"] = reportTemplate;
        _templates["invoice"] = invoiceTemplate;
        _templates["letter"] = letterTemplate;

        Console.WriteLine($"[Registry] Initialized {_templates.Count} templates");
    }

    // Get clone of template
    public Document CreateDocument(string templateName)
    {
        if (!_templates.TryGetValue(templateName, out var template))
        {
            throw new ArgumentException($"Template '{templateName}' not found");
        }

        Console.WriteLine($"[Registry] Creating document from '{templateName}' template");

        // Return deep clone to avoid modifying template
        return template.DeepClone();
    }

    public void ListTemplates()
    {
        Console.WriteLine("\n=== Available Templates ===");
        foreach (var kvp in _templates)
        {
            Console.WriteLine($"- {kvp.Key}: {kvp.Value.Title}");
        }
        Console.WriteLine();
    }
}