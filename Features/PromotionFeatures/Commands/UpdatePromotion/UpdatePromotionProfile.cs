using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.PromotionFeatures.Commands.UpdatePromotion
{
    public class UpdatePromotionProfile : Profile
    {
        public UpdatePromotionProfile()
        {
            CreateMap<WebBanHang.Entity.Promotion, UpdatePromotionResult>();
        }
    }
}
