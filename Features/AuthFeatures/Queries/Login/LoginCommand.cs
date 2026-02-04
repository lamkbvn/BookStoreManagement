using MediatR;

namespace WebBanHang.Features.AuthFeatures.Queries.Login
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public required string username { get; set; }
        public required string password { get; set; }
    }
}
