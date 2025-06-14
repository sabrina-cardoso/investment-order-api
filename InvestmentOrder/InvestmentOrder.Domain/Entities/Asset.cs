namespace InvestmentOrder.Domain.Entities;

public class Asset
{
    public int Id { get; set; }
    public string Code { get; set; }
    public AssetType Type { get; set; }
    public decimal Price { get; set; }
    public DateTime LastUpdated { get; set; }
}

