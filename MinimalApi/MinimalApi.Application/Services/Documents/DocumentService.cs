using System.Text;
using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Services.Documents;

public class DocumentService : IDocumentService
{
    public DocumentResponse ProcessFile(StringBuilder fileContent, int linesCount, int x)
    {
        var documents = new List<Document>();
        var positionSum = 0m;
        var xCount = 0;
        var productWithMaxNetValue = "";

        var lines = fileContent.ToString().Split("\n");

        var firstLine = lines.First().Split(",");

        var document = DocumentMapper.MapToDocument(firstLine[1..]);
        documents.Add(document);
        document.Position = new List<Position>();

        foreach (var line in lines[1..])
        {
            if (line.StartsWith('H'))
            {
                if (document.Position.Count > x)
                    xCount++;
                
                var splitLine = line.Split(",");
                document = DocumentMapper.MapToDocument(splitLine[1..]);
                document.Position = new List<Position>();
                documents.Add(document);
            }

            if (line.StartsWith('B'))
            {
                var splitLine = line.Split(",");
                var position = PositionMapper.MapToPosition(splitLine[1..]);
                document.Position.Add(position);
                positionSum += position.NetWorth;
            }
        }
        
        if (document.Position.Count > x)
            xCount++;

        return new DocumentResponse
        {
            Documents = documents, LineCount = linesCount, CharCount = fileContent.Length, Sum = positionSum,
            Xcount = xCount, ProductWithMaxNetValue = productWithMaxNetValue
        };
    }
}