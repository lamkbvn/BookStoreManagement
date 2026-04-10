using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface ISupplierRepository
    {
        Task<Supplier> AddAsync(Supplier supplier);
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameExceptIdAsync(string name, int exceptId);
        Task<Supplier> UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
    }
}

