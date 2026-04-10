using MediatR;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;

namespace WebBanHang.Features.SupplierFeatures.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteSupplierHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (supplier is null)
                throw new AppException("Supplier not found", StatusCodes.Status404NotFound);

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

