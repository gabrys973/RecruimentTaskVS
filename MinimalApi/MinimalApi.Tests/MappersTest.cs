using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;
using MinimalApi.Application.Services.Exceptions;

namespace MinimalApi.Tests;

public class MappersTest
{
    [Test]
    public void MapDocument_Success()
    {
        var data = "H,012,Test,033,30-01-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,151.21,0.00,0.00,0.00,";

        var result = DocumentMapper.MapToDocument(data);

        Assert.That(result.DayNumber, Is.EqualTo(123));
    }
    
    [Test]
    public void MapDocumentInvalidOperationData_Exception()
    {
        var data = "H,012,Test,033,30-30-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,151.21,0.00,0.00,0.00,";
        
        Assert.Throws<InvalidFileDataException>(() => DocumentMapper.MapToDocument(data));
    }
    
    [Test]
    public void MapDocumentInvalidGross_Exception()
    {
        var data = "H,012,Test,033,30-01-2015,123,0131,Firm,000211,12-12-2001,124.21,23.23,ad151.21,0.00,0.00,0.00,";
        
        Assert.Throws<InvalidFileDataException>(() => DocumentMapper.MapToDocument(data));
    }

    [Test]
    public void MapPosition_Success()
    {
        var data = "B,01315,GAZETA LUBUSKA P/PT.,1.000,1.55000,1.55,0.12,0.000,0.00000,1.000,1.55000,1118,";

        var result = PositionMapper.MapToPosition(data);

        Assert.That(result.Amount, Is.EqualTo(1));
    }
    
    [Test]
    public void MapPositionInvalidNetPrice_Exception()
    {
        var data = "B,01315,GAZETA LUBUSKA P/PT.,1.0daw00,1.55000,1.55,0.12,0.000,0.00000,1.000,1.55000,1118,";

        Assert.Throws<InvalidFileDataException>(() => DocumentMapper.MapToDocument(data));
    }
    
    [Test]
    public void MapPosition_Exception()
    {
        var data = "B,01315,GAZETA LUBUSKA P/PT.,1.000,1.55000,1.55,0.12,0.000,0.00000,1.000,1.55000,1118,";

        Assert.Throws<InvalidFileDataException>(() => DocumentMapper.MapToDocument(data));
    }
}