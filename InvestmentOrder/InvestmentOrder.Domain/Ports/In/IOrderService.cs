using InvestmentOrder.Domain.Dtos.Order;

namespace InvestmentOrder.Domain.Ports.In;

public interface IOrderService
{
    Task CreateOrder(OrderRequestDto orderDto);
}

