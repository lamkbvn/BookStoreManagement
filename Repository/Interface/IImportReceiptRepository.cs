using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IImportReceiptRepository
    {
        Task<ImportReceipt> CreateWithInventoryUpdateAsync(ImportReceipt receipt);
        Task<List<ImportReceipt>> GetAllAsync();
        Task<ImportReceipt?> GetByIdAsync(int id);
        Task<ImportReceipt?> GetTrackedByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> SupplierExistsAsync(int supplierId);
        Task<bool> UserExistsAsync(int userId);
        Task<bool> ProductExistsAsync(int productId);
        Task<bool> IsProductOfSupplierAsync(int productId, int supplierId);
        Task<ImportReceipt> UpdatePendingWithInventoryAdjustmentAsync(ImportReceipt receipt, List<ImportReceiptItem> newItems);
        Task DeletePendingWithInventoryRollbackAsync(ImportReceipt receipt);
        Task<ImportReceipt> UpdateAsync(ImportReceipt receipt);
    }
}
