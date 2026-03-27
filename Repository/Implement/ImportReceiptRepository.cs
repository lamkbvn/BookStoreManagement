using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class ImportReceiptRepository : IImportReceiptRepository
    {
        private readonly AppDbContext _context;

        public ImportReceiptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ImportReceipt> CreateWithInventoryUpdateAsync(ImportReceipt receipt)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            _context.ImportReceipts.Add(receipt);

            foreach (var item in receipt.ReceiptItems)
            {
                var inventory = await _context.Inventories
                    .FirstOrDefaultAsync(i => i.ProductId == item.ProductId);

                if (inventory == null)
                {
                    _context.Inventories.Add(new Inventory
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }
                else
                {
                    inventory.Quantity += item.Quantity;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return receipt;
        }

        public async Task<List<ImportReceipt>> GetAllAsync()
        {
            return await _context.ImportReceipts
                .AsNoTracking()
                .Include(x => x.Supplier)
                .Include(x => x.User)
                .Include(x => x.ReceiptItems)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<ImportReceipt?> GetByIdAsync(int id)
        {
            return await _context.ImportReceipts
                .AsNoTracking()
                .Include(x => x.Supplier)
                .Include(x => x.User)
                .Include(x => x.ReceiptItems)
                    .ThenInclude(ri => ri.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ImportReceipt?> GetTrackedByIdAsync(int id)
        {
            return await _context.ImportReceipts
                .Include(x => x.ReceiptItems)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.ImportReceipts.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> SupplierExistsAsync(int supplierId)
        {
            return await _context.Suppliers.AnyAsync(x => x.Id == supplierId);
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.Users.AnyAsync(x => x.Id == userId);
        }

        public async Task<bool> ProductExistsAsync(int productId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId);
        }

        public async Task<bool> IsProductOfSupplierAsync(int productId, int supplierId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId && x.SupplierId == supplierId);
        }

        public async Task<ImportReceipt> UpdatePendingWithInventoryAdjustmentAsync(
            ImportReceipt receipt,
            List<ImportReceiptItem> newItems)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            foreach (var oldItem in receipt.ReceiptItems.ToList())
            {
                var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.ProductId == oldItem.ProductId);
                if (inventory == null || inventory.Quantity < oldItem.Quantity)
                    throw new AppException("Không đủ tồn kho để sửa phiếu nhập", 400);

                inventory.Quantity -= oldItem.Quantity;
            }

            _context.ImportReceiptItems.RemoveRange(receipt.ReceiptItems);

            receipt.ReceiptItems = newItems;
            receipt.TotalAmount = newItems.Sum(x => x.Quantity * x.UnitCost);

            foreach (var item in newItems)
            {
                var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.ProductId == item.ProductId);
                if (inventory == null)
                {
                    _context.Inventories.Add(new Inventory
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }
                else
                {
                    inventory.Quantity += item.Quantity;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return receipt;
        }

        public async Task DeletePendingWithInventoryRollbackAsync(ImportReceipt receipt)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            foreach (var item in receipt.ReceiptItems)
            {
                var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.ProductId == item.ProductId);
                if (inventory == null || inventory.Quantity < item.Quantity)
                    throw new AppException("Không đủ tồn kho để xóa phiếu nhập", 400);

                inventory.Quantity -= item.Quantity;
            }

            _context.ImportReceiptItems.RemoveRange(receipt.ReceiptItems);
            _context.ImportReceipts.Remove(receipt);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task<ImportReceipt> UpdateAsync(ImportReceipt receipt)
        {
            _context.ImportReceipts.Update(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }
    }
}
