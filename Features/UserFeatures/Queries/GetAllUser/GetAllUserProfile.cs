using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserProfile : Profile
    {
        public GetAllUserProfile()
        {
            CreateMap<User, GetAllUserResult>();
        }
    }
}
