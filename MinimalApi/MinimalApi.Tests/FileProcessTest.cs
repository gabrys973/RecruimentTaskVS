using System.Text;
using MinimalApi.Application.Services.Documents;

namespace MinimalApi.Tests;

public class FileProcessTest
{
    private IDocumentService _documentService;

    [SetUp]
    public void Setup()
    {
        _documentService = new DocumentService();
    }

    [Test]
    public void ProcessDocumentWithOneDocument()
    {
        var stringBuilder =
            new StringBuilder(
                "H,012,Test,033,30-01-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,151.21,0.00,0.00,0.00");

        var result = _documentService.ProcessFileToDocument(stringBuilder, 1, 2);

        Assert.That(result.Documents.Count, Is.EqualTo(1));
    }

    [Test]
    public void ProcessDocumentWithOnePosition()
    {
        var stringBuilder =
            new StringBuilder(
                "H,012,Test,033,30-01-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,151.21,0.00,0.00,0.00,\n" +
                "B,25947,AUTO —WIAT CLASSIC,-2.000,14.74000,-29.48,-2.36,3.000,14.74000,1.000,14.74000,1117,");

        var result = _documentService.ProcessFileToDocument(stringBuilder, 1, 2);

        Assert.That(result.Documents.Count, Is.EqualTo(1));
        Assert.That(result.Documents.First().Position.Count, Is.EqualTo(1));
    }
}