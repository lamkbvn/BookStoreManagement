using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.SupplierFeatures.Commands.CreateSupplier
{
    public class CreateSupplierProfile : Profile
    {
        public CreateSupplierProfile()
        {
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<Supplier, CreateSupplierResult>();
        }
    }
}

