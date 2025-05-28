using InvestmentOrder.Domain.Dtos;
using InvestmentOrder.Domain.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentOrder.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateInvestmentOrderUseCase _useCase;

    public OrderController(ICreateInvestmentOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderDto order)
    {
        await _useCase.ExecuteAsync(order);
        return Ok(new { message = "Ordem publicada com sucesso", order });
    }
}

