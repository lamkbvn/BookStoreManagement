using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(Exists).WithMessage("Category not found");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken)
            => await _categoryRepository.ExistsByIdAsync(id);
    }
}

