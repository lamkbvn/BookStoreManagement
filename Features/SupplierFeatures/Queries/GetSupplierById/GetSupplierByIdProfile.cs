using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSupplierById
{
    public class GetSupplierByIdProfile : Profile
    {
        public GetSupplierByIdProfile()
        {
            CreateMap<Supplier, GetSupplierByIdResult>();
        }
    }
}

