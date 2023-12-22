using System.Text;
using MinimalApi.Application.Services.Documents;

namespace MinimalApi.Tests;

public class FileProcessTest
{
    private IDocumentService _documentService;
    private StringBuilder _data;

    [SetUp]
    public void Setup()
    {
        _documentService = new DocumentService();
        _data = new StringBuilder(
            "H,012,Test,033,30-01-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,151.21,0.00,0.00,0.00,\n" +
            "B,01315,GAZETA LUBUSKA P/PT.,1.000,1.55000,1.55,0.12,0.000,0.00000,1.000,1.55000,1118,\n" +
            "B,06152,ANGORA,2.000,2.96000,5.92,0.47,2.000,2.96000,4.000,2.96000,1117,\n" +
            "B,06353,VIVA VAT 8%,2.000,0.74000,1.48,0.12,0.000,2.44000,2.000,0.74000,1117,\n" +
            "H,5308,02,00130,29-01-2015,5222,10140,KOL S.A.,20150128099911,28-01-2015,-34.37,-2.75,-37.12,0.00,0.00,0.00,\n" +
            "B,00798,PALL MALL WH.BLUE,10.000,9.63000,96.30,22.15,5.000,9.63000,15.000,9.63000,1124,\n" +
            "B,00810,LUCKY STRIKE BLUE 23,8.000,11.45000,91.60,21.07,11.000,11.45000,19.000,11.45000,1124,\n" +
            "H,5308,08,00135,29-01-2015,5222,10998,S3 POLSKA,2015-01-29/2,29-01-2015,-8.00,-1.84,-9.84,0.00,0.00,0.00,\n" +
            "B,01018,D2G TOST POL/JAJ.KSI,2.000,5.08000,10.16,0.81,-10.000,0.00000,-8.000,0.00000,1015,");
    }

    [Test]
    public void CheckDocumentCount()
    {
        var result = _documentService.ProcessFile(_data, 9, 1);

        Assert.That(result.Documents.Count, Is.EqualTo(3));
    }
    
    [TestCase(0, 3)]
    [TestCase(1, 2)]
    [TestCase(2, 1)]
    public void CheckPositionsCount(int documentIndex, int count)
    {
        var result = _documentService.ProcessFile(_data, 9, 2);

        Assert.That(result.Documents.Count, Is.GreaterThan(documentIndex));
        Assert.That(result.Documents[documentIndex].Position.Count, Is.EqualTo(count));
    }

    [TestCase(0, 3)]
    [TestCase(1, 2)]
    [TestCase(2, 1)]
    public void CheckResultXCount(int x, int count)
    {
        var result = _documentService.ProcessFile(_data, 9, x);

        Assert.That(result.Xcount, Is.EqualTo(count));
    }

    
}