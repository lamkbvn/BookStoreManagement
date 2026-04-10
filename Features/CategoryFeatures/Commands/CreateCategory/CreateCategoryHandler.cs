using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryHandler
    : IRequestHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_categories";

        public CreateCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IDistributedCache cache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<CreateCategoryResult> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var createdCategory = await _categoryRepository.AddAsync(category);

            // Xóa cache khi tạo category mới
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);

            return _mapper.Map<CreateCategoryResult>(createdCategory);
        }
    }
}
