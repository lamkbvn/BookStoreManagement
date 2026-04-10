using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;

namespace WebBanHang.Features.SupplierFeatures.Commands.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierResult>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSupplierHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateSupplierResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (existing is null)
                throw new AppException("Supplier not found", StatusCodes.Status404NotFound);

            existing.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateSupplierResult>(existing);
        }
    }
}

