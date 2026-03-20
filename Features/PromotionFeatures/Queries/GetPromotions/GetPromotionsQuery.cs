using MediatR;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotions
{
    public class GetPromotionsQuery : IRequest<List<GetPromotionsResult>>
    {
    }
}
