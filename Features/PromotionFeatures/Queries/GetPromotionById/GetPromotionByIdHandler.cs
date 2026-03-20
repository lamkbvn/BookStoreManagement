using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotionById
{
    public class GetPromotionByIdHandler
        : IRequestHandler<GetPromotionByIdQuery, GetPromotionByIdResult>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByIdHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<GetPromotionByIdResult> Handle(
            GetPromotionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new InvalidOperationException($"Promotion with id {request.Id} not found");

            return _mapper.Map<GetPromotionByIdResult>(promotion);
        }
    }
}
