using MediatR;

namespace WebBanHang.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdCommand : IRequest<GetUserByIdResult>
    {
        public required int Id { get; set; }
    }
}
