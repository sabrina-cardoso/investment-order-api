using InvestmentOrder.Domain.Dtos.Order;

namespace InvestmentOrder.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public Investor Investor { get; set; }
    public string Asset { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Order(string asset, int amount, Investor investor, decimal price)
    {
        this.Investor = investor;
        Asset = asset;
        Amount = amount;
        Price = price;
        this.Status = OrderStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public static Order Create(OrderRequestDto order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order), "Order cannot be null"); 

        if (order.InvestorId <= 0)
            throw new ArgumentException("Investor ID must be greater than zero", nameof(order.InvestorId));

        if (string.IsNullOrWhiteSpace(order.Asset))
            throw new ArgumentException("Asset is required", nameof(order.Asset));

        if (order.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero", nameof(order.Amount));

        if (order.Price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(order.Price));


        return new Order(order.Asset, order.Amount, new Investor { Id = order.InvestorId }, order.Price);
    }
}

