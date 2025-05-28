using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.Out;

    public interface IInvestmentOrderProducer
    {
        Task PublishAsync(Order order);
    }

