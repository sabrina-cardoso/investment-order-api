using InvestmentOrder.Domain.Dtos;
using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.In;

public interface ICreateInvestmentOrderUseCase
{
    Task ExecuteAsync(OrderDto orderDto);
}

