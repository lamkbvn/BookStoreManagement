using MediatR;
using WebBanHang.Enum;

namespace WebBanHang.Features.UserFeatures.Command.Register
{
    public class RegisterCommand : IRequest<RegisterResult>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Fullname { get; set; }

        public required Role Role { get; set; }
    }
}
