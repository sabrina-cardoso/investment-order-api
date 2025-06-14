using InvestmentOrder.Domain.Dtos.Order;
using InvestmentOrder.Domain.Entities;
using InvestmentOrder.Domain.Ports.In;
using InvestmentOrder.Domain.Ports.Out;

namespace InvestmentOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IInvestmentOrderProducer _producer;

        public OrderService(IInvestmentOrderProducer producer)
        {
            _producer = producer;
        }

        public async Task CreateOrder(OrderRequestDto orderDto)
        {
            try
            {
                var order = Order.Create(orderDto);
                await _producer.PublishAsync(order);
            }
            catch (Exception ex)
            {
                //logar erro
                throw;
            }
            
        }
    }
}
