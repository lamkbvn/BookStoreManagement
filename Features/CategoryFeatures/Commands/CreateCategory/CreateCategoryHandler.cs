using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryHandler
    : IRequestHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResult> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {


            var category = _mapper.Map<Category>(request);

            var createdCategory = await _categoryRepository.AddAsync(category);

            return _mapper.Map<CreateCategoryResult>(createdCategory);
        }
    }
}
