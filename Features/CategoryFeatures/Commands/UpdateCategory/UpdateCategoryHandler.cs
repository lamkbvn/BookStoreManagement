using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_categories";

        public UpdateCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<UpdateCategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _categoryRepository.GetByIdAsync(request.Id);
            if (existing is null)
            {
                throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            existing.Name = request.Name;
            existing.Description = request.Description ?? "";

            var updated = await _categoryRepository.UpdateAsync(existing);

            // Xóa cache khi cập nhật category
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"category_{request.Id}", cancellationToken);

            return _mapper.Map<UpdateCategoryResult>(updated);
        }
    }
}

