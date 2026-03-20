using MediatR;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById
{
    public class GetPromotionByIdQuery : IRequest<GetPromotionByIdResult>
    {
        public int Id { get; set; }
    }
}
