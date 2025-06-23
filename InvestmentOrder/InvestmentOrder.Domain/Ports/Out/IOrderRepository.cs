using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.Out;

interface IOrderRepository
{
    Task<bool> CreateOrderAsync(Order order);
    Task<Order?> GetOrderByIdAsync(Guid orderId);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<bool> UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(Guid orderId);
}

