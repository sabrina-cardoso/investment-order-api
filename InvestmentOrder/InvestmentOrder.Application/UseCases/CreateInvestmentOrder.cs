using InvestmentOrder.Domain.Dtos;
using InvestmentOrder.Domain.Entities;
using InvestmentOrder.Domain.Ports.In;
using InvestmentOrder.Domain.Ports.Out;

namespace InvestmentOrder.Application.UseCases
{
    public class CreateInvestmentOrder : ICreateInvestmentOrderUseCase
    {
        private readonly IInvestmentOrderProducer _producer;

        public CreateInvestmentOrder(IInvestmentOrderProducer producer)
        {
            _producer = producer;
        }

        public async Task ExecuteAsync(OrderDto orderDto)
        {
            var order = new Order(orderDto);
            await _producer.PublishAsync(order);
        }
    }
}
