using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.CategoryFeatures.Commands.CreateCategory;
using WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory;
using WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory;
using WebBanHang.Features.CategoryFeatures.Queries.GetCategories;
using WebBanHang.Features.CategoryFeatures.Queries.GetCategoryById;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize(Roles = "Admin,Staff")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetCategoriesQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return this.AutoResponse(result);
    }
}
