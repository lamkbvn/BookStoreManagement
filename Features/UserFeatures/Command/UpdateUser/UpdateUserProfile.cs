using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.UserFeatures.Command.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserResult>();
        }
    }
}
