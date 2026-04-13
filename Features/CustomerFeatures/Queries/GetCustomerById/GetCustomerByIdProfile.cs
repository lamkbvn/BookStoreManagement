using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomerById
{
    public class GetCustomerByIdProfile : Profile
    {
        public GetCustomerByIdProfile()
        {
            CreateMap<Customer, GetCustomerByIdResult>();
        }

    }
}
