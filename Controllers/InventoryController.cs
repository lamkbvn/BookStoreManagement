using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.InventoryFeatures.Commands.CreateInventory;
using WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory;
using WebBanHang.Features.InventoryFeatures.Commands.DeleteInventory;
using WebBanHang.Features.InventoryFeatures.Commands.IncreaseInventory;
using WebBanHang.Features.InventoryFeatures.Commands.UpdateInventory;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventories;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/inventories")]
[Authorize(Roles = "Admin,Staff")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetInventoriesQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetInventoryByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInventoryCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateInventoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPatch("{id:int}/increase")]
    public async Task<IActionResult> Increase(int id, IncreaseInventoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPatch("{id:int}/decrease")]
    public async Task<IActionResult> Decrease(int id, DecreaseInventoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteInventoryCommand { Id = id });
        return this.AutoResponse(result);
    }
}

