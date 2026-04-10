using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.ImportReceiptFeatures.Commands.ApproveImportReceipt;
using WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt;
using WebBanHang.Features.ImportReceiptFeatures.Commands.DeleteImportReceipt;
using WebBanHang.Features.ImportReceiptFeatures.Commands.UpdateImportReceipt;
using WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceiptById;
using WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceipts;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/import-receipts")]
public class ImportReceiptController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImportReceiptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetImportReceiptsQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetImportReceiptByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateImportReceiptCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateImportReceiptCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPatch("{id:int}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        var result = await _mediator.Send(new ApproveImportReceiptCommand { Id = id });
        return this.AutoResponse(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteImportReceiptCommand { Id = id });
        return this.AutoResponse(result);
    }
}
