using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.UserFeatures.Command.Register
{
    public class RegisterCommandProfile : Profile
    {
        public RegisterCommandProfile()
        {
            CreateMap<RegisterCommand, User>();
            CreateMap<User, RegisterResult>();
        }
    }
}
