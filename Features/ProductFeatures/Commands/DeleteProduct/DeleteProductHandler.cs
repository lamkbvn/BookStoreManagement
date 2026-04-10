using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_products";

        public DeleteProductHandler(IProductRepository productRepository, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTrackedByIdAsync(request.Id);
            if (product is null)
            {
                throw new AppException("Product not found", StatusCodes.Status404NotFound);
            }

            await _productRepository.DeleteAsync(product);
            
            // Xóa cache khi xóa sản phẩm
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            
            return Unit.Value;
        }
    }
}

