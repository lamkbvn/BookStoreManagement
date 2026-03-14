using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResult>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (existing is null)
            {
                throw new AppException("Category not found", StatusCodes.Status404NotFound);
            }

            existing.Name = request.Name;
            existing.Description = request.Description ?? "";

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UpdateCategoryResult>(existing);
        }
    }
}

