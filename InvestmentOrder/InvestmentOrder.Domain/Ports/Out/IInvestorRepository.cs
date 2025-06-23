using InvestmentOrder.Domain.Entities;

namespace InvestmentOrder.Domain.Ports.Out;

public interface IInvestorRepository
{
    Task<Investor> GetByIdAsync(int id);
    Task<IEnumerable<Investor>> GetAllAsync();
    Task<bool> AddAsync(Investor investor);
}

