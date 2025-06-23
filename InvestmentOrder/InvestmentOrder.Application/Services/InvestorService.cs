using InvestmentOrder.Domain.Dtos.Investor;
using InvestmentOrder.Domain.Entities;
using InvestmentOrder.Domain.Ports.In;
using InvestmentOrder.Domain.Ports.Out;
using Microsoft.Extensions.Logging;

namespace InvestmentOrder.Application.Services;

public class InvestorService : IInvestorService
{
    private readonly IInvestorRepository _investorRepository;
    private readonly ILogger<IInvestorRepository> _logger;

    public InvestorService(IInvestorRepository investorRepository, ILogger<IInvestorRepository> logger)
    {
        _investorRepository = investorRepository;
        _logger = logger;
    }

    public async Task<bool> CreateAsync(InvestorRequestDto investorDto)
    {
        try
        {
            Investor investor = Investor.Create(
                investorDto.Name,
                investorDto.Document,
                investorDto.Profile
            );

            return await _investorRepository.AddAsync( investor );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, string.Format("Error creating investor: {0}", ex.Message));
            return false;
        }
    }

    public Task<Investor> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

