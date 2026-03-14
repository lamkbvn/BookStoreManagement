using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdProfile : Profile
    {
        public GetCategoryByIdProfile()
        {
            CreateMap<Category, GetCategoryByIdResult>();
        }
    }
}

