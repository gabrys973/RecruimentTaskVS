using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Services.Documents;

public class DocumentResponse
{
    public List<Document> Documents { get; internal init; }
    public int LineCount { get; set; }
    public int CharCount { get; set; }
    public decimal Sum { get; set; }
    public int Xcount { get; set; }
    public string PositionWithMaxNetPrice { get; set; }
}