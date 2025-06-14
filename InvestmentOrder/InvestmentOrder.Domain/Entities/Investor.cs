namespace InvestmentOrder.Domain.Entities;

public class Investor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime CreatedAt { get; set; }
    public InvestorProfile Profile { get; set; }
}

