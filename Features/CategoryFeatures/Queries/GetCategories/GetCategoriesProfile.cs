using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesProfile : Profile
    {
        public GetCategoriesProfile()
        {
            CreateMap<Category, GetCategoriesResult>();
        }
    }
}

