using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameExceptIdAsync(string name, int exceptId);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
