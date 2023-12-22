using System.Text;
using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Services.Documents;

public class DocumentService : IDocumentService
{
    public DocumentResponse ProcessFileToDocument(StringBuilder fileContent, int linesCount, int x)
    {
        var documents = new List<Document>();
        var positionSum = 0m;
        var xCount = 0;
        var productWithMaxNetValue = "";

        var lines = fileContent.ToString().Split("\n");

        var firstLine = lines.First().Split(",");

        var document = DocumentMapper.MapToDocument(firstLine[1..]);
        documents.Add(document);

        foreach (var line in lines[1..])
        {
            if (line.StartsWith('H'))
            {
                var splitLine = line.Split(",");
                document = DocumentMapper.MapToDocument(splitLine[1..]);
                documents.Add(document);
            }

            if (line.StartsWith('B'))
            {
                var splitLine = line.Split(",");
                var position = PositionMapper.MapToPosition(splitLine[1..]);
                document.Position.Add(position);
            }
        }

        return new DocumentResponse
        {
            Documents = documents, LineCount = linesCount, CharCount = fileContent.Length, Sum = positionSum,
            Xcount = xCount, ProductWithMaxNetValue = productWithMaxNetValue
        };
    }
}