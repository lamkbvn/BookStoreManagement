using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<GetProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<GetProductsResult>>(products);
        }
    }
}

