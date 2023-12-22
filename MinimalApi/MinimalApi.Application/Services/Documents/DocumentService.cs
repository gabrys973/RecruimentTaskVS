using System.Text;
using MinimalApi.Application.Mappers.Documents;
using MinimalApi.Application.Mappers.Positions;
using MinimalApi.Application.Services.Exceptions;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Services.Documents;

public class DocumentService : IDocumentService
{
    public DocumentResponse ProcessFile(StringBuilder fileContent, int linesCount, int x)
    {
        var documents = new List<Document>();
        var positionSum = 0m;
        var xCount = 0;

        var positionMaxPrice = 0m;
        var positionWithMaxNetValue = "";

        var lines = fileContent.ToString().Split("\n");

        var firstLine = lines.First();
        var document = DocumentMapper.MapToDocument(firstLine);
        documents.Add(document);
        document.Position = new List<Position>();

        foreach (var line in lines[1..])
        {
            if (line.StartsWith('H'))
            {
                if (document.Position.Count > x)
                    xCount++;

                document = DocumentMapper.MapToDocument(line);
                document.Position = new List<Position>();
                documents.Add(document);
                continue;
            }

            if (line.StartsWith('B'))
            {
                var position = PositionMapper.MapToPosition(line);
                document.Position.Add(position);
                positionSum += position.NetWorth;

                if (position.NetPrice > positionMaxPrice)
                {
                    positionMaxPrice = position.NetPrice;
                    positionWithMaxNetValue = position.Name;
                }
                continue;
            }
            
            if (!line.StartsWith('C') && !string.IsNullOrEmpty(line))
                throw new InvalidFileDataException();
        }

        if (document.Position.Count > x)
            xCount++;

        return new DocumentResponse
        {
            Documents = documents, LineCount = linesCount, CharCount = fileContent.Length, Sum = positionSum,
            Xcount = xCount, PositionWithMaxNetPrice = positionWithMaxNetValue
        };
    }
}