using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById
{
    public class GetPromotionByIdProfile : Profile
    {
        public GetPromotionByIdProfile()
        {
            CreateMap<Promotion, GetPromotionByIdResult>();
        }
    }
}
