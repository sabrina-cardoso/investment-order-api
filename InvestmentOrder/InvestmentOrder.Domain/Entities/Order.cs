using InvestmentOrder.Domain.Dtos;

namespace InvestmentOrder.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string Asset { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public Order(int id, string asset, int quantity, string type)
    {
        Asset = asset;
        Quantity = quantity;
        Type = type;
    }

    public Order(OrderDto orderDto)
    {
        Asset = orderDto.Asset;
        Quantity = orderDto.Quantity;
        Type = orderDto.Type;
    }
}

