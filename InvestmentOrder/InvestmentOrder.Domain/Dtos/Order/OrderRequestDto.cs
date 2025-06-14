using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrder.Domain.Dtos.Order;
public class OrderRequestDto
{
    public int InvestorId { get; set; }
    public string Asset { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

    private OrderRequestDto(int investorId, string asset, int amount, decimal price)
    {
        InvestorId = investorId;
        Asset = asset;
        Amount = amount;
        Price = price;
    }

    public static OrderRequestDto Create(int investorId, string asset, int amount, decimal price)
    {
        if (investorId <= 0)
            throw new ArgumentException("Investor ID must be greater than zero", nameof(investorId));

        if (string.IsNullOrWhiteSpace(asset))
            throw new ArgumentException("Asset is required", nameof(asset));

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero", nameof(amount));

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));


        return new OrderRequestDto(investorId, asset, amount, price);
    }
}

