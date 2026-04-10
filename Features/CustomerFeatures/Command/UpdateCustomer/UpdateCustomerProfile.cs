using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CustomerFeatures.Command.UpdateCustomer
{
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, UpdateCustomerResult>();
        }
    }
}
