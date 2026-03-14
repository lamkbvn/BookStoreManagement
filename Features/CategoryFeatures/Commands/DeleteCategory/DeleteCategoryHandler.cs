using MediatR;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;

namespace WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteCategoryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (category is null)
            {
                throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

