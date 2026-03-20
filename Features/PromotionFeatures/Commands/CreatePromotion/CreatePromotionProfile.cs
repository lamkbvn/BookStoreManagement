using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.PromotionFeatures.Commands.CreatePromotion
{
    public class CreatePromotionProfile : Profile
    {
        public CreatePromotionProfile()
        {
            CreateMap<Promotion, CreatePromotionResult>();
        }
    }
}
