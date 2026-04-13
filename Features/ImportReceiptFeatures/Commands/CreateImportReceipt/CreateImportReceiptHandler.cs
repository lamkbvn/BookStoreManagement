using AutoMapper;
using MediatR;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Enum;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Commands.CreateImportReceipt
{
    public class CreateImportReceiptHandler : IRequestHandler<CreateImportReceiptCommand, CreateImportReceiptResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IMapper _mapper;

        public CreateImportReceiptHandler(
            AppDbContext dbContext,
            IImportReceiptRepository importReceiptRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _importReceiptRepository = importReceiptRepository;
            _mapper = mapper;
        }

        public async Task<CreateImportReceiptResult> Handle(CreateImportReceiptCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var receipt = new ImportReceipt
                {
                    SupplierId = request.SupplierId,
                    UserId = request.UserId,
                    ImportDate = DateTime.Now,
                    Status = ImportReceiptStatus.Pending,
                    ReceiptItems = request.ReceiptItems.Select(x => new ImportReceiptItem
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        UnitCost = x.UnitCost
                    }).ToList()
                };

                receipt.TotalAmount = receipt.ReceiptItems.Sum(x => x.Quantity * x.UnitCost);

                var created = await _importReceiptRepository.CreateWithInventoryUpdateAsync(receipt);
                var result = await _importReceiptRepository.GetByIdAsync(created.Id);

                if (result == null)
                    throw new InvalidOperationException($"Import receipt with id {created.Id} not found");

                await transaction.CommitAsync(cancellationToken);
                return _mapper.Map<CreateImportReceiptResult>(result);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
