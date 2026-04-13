using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.SupplierFeatures.Commands.CreateSupplier;
using WebBanHang.Features.SupplierFeatures.Commands.DeleteSupplier;
using WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier;
using WebBanHang.Features.SupplierFeatures.Queries.GetSupplierById;
using WebBanHang.Features.SupplierFeatures.Queries.GetSuppliers;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/suppliers")]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetSuppliersQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetSupplierByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateSupplierCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, UpdateSupplierCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteSupplierCommand { Id = id });
        return this.AutoResponse(result);
    }
}

