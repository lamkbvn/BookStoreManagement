using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.SupplierFeatures.Commands.CreateSupplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResult>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<CreateSupplierResult> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request);
            var created = await _supplierRepository.AddAsync(supplier);
            return _mapper.Map<CreateSupplierResult>(created);
        }
    }
}

