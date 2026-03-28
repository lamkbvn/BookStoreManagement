using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;

namespace WebBanHang.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IDistributedCache _cache;
        private const string CACHE_KEY = "all_categories";

        public DeleteCategoryHandler(AppDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
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

            // Xóa cache khi xóa category
            await _cache.RemoveAsync(CACHE_KEY, cancellationToken);
            await _cache.RemoveAsync($"category_{request.Id}", cancellationToken);

            return Unit.Value;
        }
    }
}

