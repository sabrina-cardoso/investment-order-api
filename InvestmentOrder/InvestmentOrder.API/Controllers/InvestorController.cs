using InvestmentOrder.Domain.Dtos.Investor;
using InvestmentOrder.Domain.Dtos.Order;
using InvestmentOrder.Domain.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentOrder.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class InvestorController : ControllerBase
{
    private readonly IInvestorService _investorService;

    public InvestorController(IInvestorService investorService)
    {
        _investorService = investorService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InvestorRequestDto investor)
    {
        bool created = await _investorService.CreateAsync(investor);

        if (!created)
        {
            return BadRequest(new { message = "Investor could not be created." });
        }

        return Ok(new { message = "Investor created!", investor });
    }
}

