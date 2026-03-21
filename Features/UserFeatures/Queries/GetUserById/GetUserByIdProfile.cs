using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdProfile : Profile
    {
        public GetUserByIdProfile()
        {
            CreateMap<User, GetUserByIdResult>();
        }
    }
}
