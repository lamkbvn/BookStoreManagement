using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.PromotionFeatures.Commands.CreatePromotion;
using WebBanHang.Features.PromotionFeatures.Commands.DeletePromotion;
using WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion;
using WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById;
using WebBanHang.Features.PromotionFeatures.Queries.GetPromotions;

namespace WebBanHang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetAllPromotions()
        {
            var result = await _mediator.Send(new GetPromotionsQuery());
            return this.AutoResponse(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var result = await _mediator.Send(new GetPromotionByIdQuery { Id = id });
            return this.AutoResponse(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionCommand command)
        {
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePromotion(int id, [FromBody] UpdatePromotionCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var result = await _mediator.Send(new DeletePromotionCommand { Id = id });
            return this.AutoResponse(result);
        }
    }
}
