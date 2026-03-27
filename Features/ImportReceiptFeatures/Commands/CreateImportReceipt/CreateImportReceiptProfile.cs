using AutoMapper;
using WebBanHang.Entity;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class CreateImportReceiptProfile : Profile
    {
        public CreateImportReceiptProfile()
        {
            CreateMap<ImportReceipt, CreateImportReceiptResult>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Fullname))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.ReceiptItems.Count))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));

            CreateMap<ImportReceiptItem, ImportReceiptItemResultDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.Quantity * src.UnitCost));
        }
    }
}
