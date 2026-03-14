using MediatR;

namespace WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

