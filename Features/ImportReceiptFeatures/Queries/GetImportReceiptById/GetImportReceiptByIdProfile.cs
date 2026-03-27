using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceiptById
{
    public class GetImportReceiptByIdProfile : Profile
    {
        public GetImportReceiptByIdProfile()
        {
            CreateMap<ImportReceipt, GetImportReceiptByIdResult>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Fullname))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.ReceiptItems.Count))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));
        }
    }
}
