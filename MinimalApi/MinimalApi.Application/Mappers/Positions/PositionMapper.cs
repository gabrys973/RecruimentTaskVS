using System.Globalization;
using MinimalApi.Application.Services.Exceptions;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Mappers.Positions;

public static class PositionMapper
{
    public static Position MapToPosition(string data)
    {
        try
        {
            var splitData = data.Split(",")[1..];
            var document = new Position();

            Action<string>[] propertyMappings =
            {
                x => document.Code = x,
                x => document.Name = x,
                x => document.Amount = (int)decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.NetPrice = decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.NetWorth = decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.Vat = decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.AmountBefore = (int)decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.AvgBefore = decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.AmountAfter = (int)decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.AvgAfter = decimal.Parse(x, CultureInfo.InvariantCulture),
                x => document.Group = x
            };

            for (var i = 0; i < propertyMappings.Length; i++)
            {
                propertyMappings[i](splitData[i]);
            }

            return document;
        }
        catch (Exception)
        {
            throw new InvalidFileDataException();
        }
    }
}