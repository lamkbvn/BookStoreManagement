using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomers
{
    public class GetCustomersProfile : Profile
    {
        public GetCustomersProfile()
        {
            CreateMap<Customer, GetCustomersResult>();
        }
    }
}
