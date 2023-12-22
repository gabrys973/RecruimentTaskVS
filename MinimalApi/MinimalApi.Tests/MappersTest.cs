using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;

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
    public void MapPosition_Success()
    {
        var data = "B,01315,GAZETA LUBUSKA P/PT.,1.000,1.55000,1.55,0.12,0.000,0.00000,1.000,1.55000,1118,";

        var result = PositionMapper.MapToPosition(data);

        Assert.That(result.Amount, Is.EqualTo(1));
    }
}