using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.PromotionFeatures.Queries.GetPromotions
{
    public class GetPromotionsHandler
        : IRequestHandler<GetPromotionsQuery, List<GetPromotionsResult>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionsHandler(
            IPromotionRepository promotionRepository,
            IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPromotionsResult>> Handle(
            GetPromotionsQuery request,
            CancellationToken cancellationToken)
        {
            var promotions = await _promotionRepository.GetAllAsync();
            return _mapper.Map<List<GetPromotionsResult>>(promotions);
        }
    }
}
