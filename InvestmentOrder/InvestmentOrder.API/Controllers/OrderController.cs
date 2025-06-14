using InvestmentOrder.Domain.Dtos.Order;
using InvestmentOrder.Domain.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentOrder.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderRequestDto order)
    {
        await _orderService.CreateOrder(order);
        return Ok(new { message = "Ordem publicada com sucesso", order });
    }
}

