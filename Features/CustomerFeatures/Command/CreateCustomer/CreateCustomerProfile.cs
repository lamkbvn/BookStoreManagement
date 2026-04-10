using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.CustomerFeatures.Command.CreateCustomer
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, CreateCustomerResult>();
        }
    }
}
