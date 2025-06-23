using System.Runtime.CompilerServices;

namespace InvestmentOrder.Domain.Entities;

public class Investor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime CreatedAt { get; set; }
    public InvestorProfile Profile { get; set; }

    private Investor(string name, string document, InvestorProfile profile)
    {
        Name = name;
        Document = document;
        Profile = profile;
        CreatedAt = DateTime.UtcNow;
    }

    private Investor(int id, string name, string document, InvestorProfile profile, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Document = document;
        Profile = profile;
        CreatedAt = createdAt;
    }

    public static Investor Create(string name, string document, InvestorProfile profile)
    {

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException("Document cannot be null or empty", nameof(document));


        return new Investor(name, document, profile);
    }

    public static Investor Load(int id, string name, string document, InvestorProfile profile, DateTime createdAt)
    {
        return new Investor(id, name, document, profile, createdAt);
    }
}

