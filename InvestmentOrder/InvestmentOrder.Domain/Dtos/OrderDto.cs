using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrder.Domain.Dtos;
public class OrderDto
{
    public string Asset { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public OrderDto(string asset, int quantity, string type)
    {
        Asset = asset;
        Quantity = quantity;
        Type = type;
    }
}

