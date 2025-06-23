using InvestmentOrder.Domain.Dtos.Investor;
using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.In;

public interface IInvestorService
{
    Task<Investor> GetByIdAsync(int id);
    Task<bool> CreateAsync(InvestorRequestDto investor);

}

