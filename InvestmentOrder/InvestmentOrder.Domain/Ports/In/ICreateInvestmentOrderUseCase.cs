using InvestmentOrder.Domain.Dtos.Order;
using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.In;

public interface IOrderService
{
    Task CreateOrder(OrderRequestDto orderDto);
}

