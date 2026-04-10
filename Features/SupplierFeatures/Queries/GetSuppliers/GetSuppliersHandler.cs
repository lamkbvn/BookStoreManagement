using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Queries.GetSuppliers
{
    public class GetSuppliersHandler : IRequestHandler<GetSuppliersQuery, List<GetSuppliersResult>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSuppliersHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSuppliersResult>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return _mapper.Map<List<GetSuppliersResult>>(suppliers);
        }
    }
}

