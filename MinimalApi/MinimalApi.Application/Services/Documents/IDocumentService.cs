using System.Text;

namespace MinimalApi.Application.Services.Documents;

public interface IDocumentService
{
    public DocumentResponse ProcessFile(StringBuilder result, int linesCount, int i);
}