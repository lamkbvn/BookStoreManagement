using MediatR;
using WebBanHang.Enum;

namespace WebBanHang.Features.UserFeatures.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        public required int Id { get; set; }
        public required string Password { get; set; }
        public required string Fullname { get; set; }
        public required Role Role { get; set; }
    }
}
