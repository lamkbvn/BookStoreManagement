using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_products";

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTrackedByIdAsync(request.Id);
            if (product is null)
            {
                throw new AppException("Product not found", StatusCodes.Status404NotFound);
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.SupplierId = request.SupplierId;

            await _productRepository.UpdateAsync(product, request.Quantity);

            var full = await _productRepository.GetByIdAsync(product.Id) ?? product;
            
            // Xóa cache khi cập nhật sản phẩm
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            
            return _mapper.Map<UpdateProductResult>(full);
        }
    }
}

