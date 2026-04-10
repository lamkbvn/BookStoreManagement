using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSuppliers
{
    public class GetSuppliersProfile : Profile
    {
        public GetSuppliersProfile()
        {
            CreateMap<Supplier, GetSuppliersResult>();
        }
    }
}

