using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetTrackedByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameExceptIdAsync(string name, int exceptId);
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<bool> SupplierExistsAsync(int supplierId);
        Task<Product> UpdateAsync(Product product, int quantity);
        Task DeleteAsync(Product product);
    }
}

