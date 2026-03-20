using MediatR;

namespace WebBanHang.Features.PromotionFeatures.Commands.DeletePromotion
{
    public class DeletePromotionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
