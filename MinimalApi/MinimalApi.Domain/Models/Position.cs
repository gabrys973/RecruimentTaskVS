namespace MinimalApi.Domain.Models;

public record Position
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal NetPrice { get; set; }
    public decimal NetWorth { get; set; }
    public decimal Vat { get; set; }
    public int AmountBefore { get; set; }
    public decimal AvgBefore { get; set; }
    public int AmountAfter { get; set; }
    public decimal AvgAfter { get; set; }
    public string Group { get; set; }
}