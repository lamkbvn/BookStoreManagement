using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.CategoryFeatures.Commands.CreateCategory;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }
}
