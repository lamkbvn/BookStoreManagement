using MediatR;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdResult>
    {
        public int Id { get; set; }
    }
}

