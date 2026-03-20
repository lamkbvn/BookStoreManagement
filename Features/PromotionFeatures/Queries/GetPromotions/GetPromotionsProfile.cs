using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotions
{
    public class GetPromotionsProfile : Profile
    {
        public GetPromotionsProfile()
        {
            CreateMap<Promotion, GetPromotionsResult>();
        }
    }
}
