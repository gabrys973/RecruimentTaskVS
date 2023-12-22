namespace MinimalApi.Domain.Models;

public class Document
{
    public string CodeBa { get; set; }
    public string Type { get; set; }
    public string Number { get; set; }
    public DateTime OperationDate { get; set; }
    public int DayNumber { get; set; }
    public string ContractorCode { get; set; }
    public string ContractorName { get; set; }
    public string ExternalDocumentNumber { get; set; }
    public DateTime ExternalDocumentDate { get; set; }
    public decimal Net { get; set; }
    public decimal Vat { get; set; }
    public decimal Gross { get; set; }
    public decimal F1 { get; set; }
    public decimal F2 { get; set; }
    public decimal F3 { get; set; }
    public List<Position> Position { get; set; } 
}