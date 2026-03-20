using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IInventoryRepository
    {
        Task<Inventory> AddAsync(Inventory inventory);
        Task<List<Inventory>> GetAllAsync();
        Task<Inventory?> GetByIdAsync(int id);
        Task<Inventory?> GetByProductIdAsync(int productId);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByProductIdAsync(int productId);
        Task<Inventory> UpdateAsync(Inventory inventory);
        Task DeleteAsync(Inventory inventory);
    }
}
