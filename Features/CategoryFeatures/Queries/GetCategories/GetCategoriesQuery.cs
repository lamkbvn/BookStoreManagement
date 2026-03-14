using MediatR;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<GetCategoriesResult>>
    {
    }
}

