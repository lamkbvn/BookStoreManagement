using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.CustomerFeatures.Command.CreateCustomer;
using WebBanHang.Features.CustomerFeatures.Command.UpdateCustomer;
using WebBanHang.Features.CustomerFeatures.Queries.GetCustomerById;
using WebBanHang.Features.CustomerFeatures.Queries.GetCustomers;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/customers")]
[Authorize(Roles = "Admin,Staff")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetCustomersQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(id));
        return this.AutoResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }
}