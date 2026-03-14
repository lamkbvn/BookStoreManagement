using MediatR;

namespace WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryResult>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}

