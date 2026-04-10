using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_categories";

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IDistributedCache cache)
        {
            _categoryRepository = categoryRepository;
            _cache = cache;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
            {
                throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            await _categoryRepository.DeleteAsync(category);

            // Xóa cache khi xóa category
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"category_{request.Id}", cancellationToken);

            return Unit.Value;
        }
    }
}

