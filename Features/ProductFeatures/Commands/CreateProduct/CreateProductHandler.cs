using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_products";

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var created = await _productRepository.AddAsync(product, request.Quantity);

            // load back with inventory for mapping quantity
            var full = await _productRepository.GetByIdAsync(created.Id) ?? created;
            
            // Xóa cache khi tạo sản phẩm mới
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            
            return _mapper.Map<CreateProductResult>(full);
        }
    }
}

