using System.Text;

namespace MinimalApi.Application.Services.Documents;

public interface IDocumentService
{
    public DocumentResponse ProcessFileToDocument(StringBuilder result, int linesCount, int i);
}