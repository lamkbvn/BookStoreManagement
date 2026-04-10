using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBanHang.Common.Exceptions;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.OrderFeatures.Commands.CreateOrder;
using WebBanHang.Features.OrderFeatures.Queries.GetOrderById;
using WebBanHang.Features.OrderFeatures.Queries.GetOrders;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/orders")]
[Authorize(Roles = "Admin,Staff")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetOrdersQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var userId) || userId <= 0)
            throw new AppException("Token không hợp lệ", StatusCodes.Status401Unauthorized);

        command.UserId = userId;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

}
