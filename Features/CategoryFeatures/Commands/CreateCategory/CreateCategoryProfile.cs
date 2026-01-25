using AutoMapper;
using WebBanHang.Entity;


namespace WebBanHang.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryProfile : Profile
    {
        public CreateCategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CreateCategoryResult>();
        }
    }
}
