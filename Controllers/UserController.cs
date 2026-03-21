using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.UserFeatures.Command.Register;
using WebBanHang.Features.UserFeatures.Command.UpdateUser;
using WebBanHang.Features.UserFeatures.Queries.GetAllUser;
using WebBanHang.Features.UserFeatures.Queries.GetUserById;

namespace WebBanHang.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserCommand());
            return this.AutoResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdCommand { Id = id });
            return this.AutoResponse(result);
        }

    }
}
