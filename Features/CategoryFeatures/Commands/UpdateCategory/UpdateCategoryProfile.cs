using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryProfile : Profile
    {
        public UpdateCategoryProfile()
        {
            CreateMap<Category, UpdateCategoryResult>();
        }
    }
}

