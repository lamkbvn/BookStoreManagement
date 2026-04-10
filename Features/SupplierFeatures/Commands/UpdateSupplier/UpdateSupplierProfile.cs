using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier
{
    public class UpdateSupplierProfile : Profile
    {
        public UpdateSupplierProfile()
        {
            CreateMap<Supplier, UpdateSupplierResult>();
        }
    }
}

