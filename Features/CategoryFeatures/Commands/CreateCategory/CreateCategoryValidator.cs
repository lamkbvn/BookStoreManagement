using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryValidator
    : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(100).WithMessage("Category name max 100 characters")
                .MustAsync(BeUniqueName).WithMessage("Category name already exists");
            ;
        }

        private async Task<bool> BeUniqueName(
    string name,
    CancellationToken cancellationToken)
        {
            return !await _categoryRepository.ExistsByNameAsync(name);
        }
    }
}
