using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Commands.CreatePromotion
{
    public class CreatePromotionHandler
        : IRequestHandler<CreatePromotionCommand, CreatePromotionResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public CreatePromotionHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<CreatePromotionResult> Handle(
            CreatePromotionCommand request,
            CancellationToken cancellationToken)
        {
            var promotion = new Promotion
            {
                Code = request.Code,
                Description = request.Description,
                DiscountPercentage = request.DiscountPercentage,
                MaximumDiscountAmount = request.MaximumDiscountAmount,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive
            };

            var createdPromotion = await _promotionRepository.AddAsync(promotion);
            return _mapper.Map<CreatePromotionResult>(createdPromotion);
        }
    }
}
