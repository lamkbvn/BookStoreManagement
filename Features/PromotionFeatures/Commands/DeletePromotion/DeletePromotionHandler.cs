using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.DeletePromotion
{
    public class DeletePromotionHandler
        : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;

        public DeletePromotionHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<bool> Handle(
            DeletePromotionCommand request,
            CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new InvalidOperationException($"Promotion with id {request.Id} not found");

            await _promotionRepository.DeleteAsync(promotion);
            return true;
        }
    }
}
