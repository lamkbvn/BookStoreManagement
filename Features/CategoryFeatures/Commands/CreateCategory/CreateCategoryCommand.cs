using MediatR;

namespace WebBanHang.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResult>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
