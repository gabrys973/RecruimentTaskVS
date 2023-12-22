using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;

namespace MinimalApi.Tests;

public class MappersTest
{
    [Test]
    public void MapToDocument_Success()
    {
        var data = new[]
        {
            "012", "Test", "033", "30-01-2015", "123.0000", "0131", "Firm", "000211", "12-12-2001", "124.21", "23.23",
            "151.21", "0.00", "0.00", "0.00"
        };

        var result = DocumentMapper.MapToDocument(data);

        Assert.That(result.DayNumber, Is.EqualTo(123));
    }

    [Test]
    public void MapToPosition_Success()
    {
        var data = new[]
        {
            "00275", "OSHEE VIT.BLACK 033L", "12.000", "1.63000", "19.56", "0.98", "11.000", "-0.12164", "23.000",
            "0.79226", "1173"
        };

        var result = PositionMapper.MapToPosition(data);

        Assert.That(result.Amount, Is.EqualTo(12));
    }
}