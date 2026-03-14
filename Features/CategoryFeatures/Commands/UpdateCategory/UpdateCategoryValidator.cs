using FluentValidation;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(Exists).WithMessage("Category not found");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(100).WithMessage("Category name max 100 characters")
                .MustAsync(BeUniqueName).WithMessage("Category name already exists");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken)
            => await _categoryRepository.ExistsByIdAsync(id);

        private async Task<bool> BeUniqueName(UpdateCategoryCommand cmd, string name, CancellationToken cancellationToken)
            => !await _categoryRepository.ExistsByNameExceptIdAsync(name, cmd.Id);
    }
}

