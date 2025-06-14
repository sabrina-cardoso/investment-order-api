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
        return new OrderRequestDto(investorId, asset, amount, price);
    }
}

