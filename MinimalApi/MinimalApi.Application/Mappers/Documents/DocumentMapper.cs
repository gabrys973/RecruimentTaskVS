using System.Globalization;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Mappers.Documents;

public static class DocumentMapper
{
    public static Document MapToDocument(string[] data)
    {
        var document = new Document();

        Action<string>[] propertyMappings =
        {
            x => document.CodeBa = x,
            x => document.Type = x,
            x => document.Number = x,
            x => document.OperationDate = DateTime.Parse(x),
            x => document.DayNumber = (int)decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.ContractorCode = x,
            x => document.ContractorName = x,
            x => document.ExternalDocumentNumber = x,
            x => document.ExternalDocumentDate = DateTime.Parse(x),
            x => document.Net = decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.Vat = decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.Gross = decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.F1 = decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.F2 = decimal.Parse(x, CultureInfo.InvariantCulture),
            x => document.F3 = decimal.Parse(x, CultureInfo.InvariantCulture),
        };

        for (var i = 0; i < propertyMappings.Length; i++)
        {
            propertyMappings[i](data[i]);
        }

        return document;
    }
}