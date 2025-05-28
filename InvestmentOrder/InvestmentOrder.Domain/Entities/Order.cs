using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrder.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string Asset { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public Order(int id, string asset, int quantity, string type)
    {
        Id = id;
        Asset = asset;
        Quantity = quantity;
        Type = type;
    }
}

