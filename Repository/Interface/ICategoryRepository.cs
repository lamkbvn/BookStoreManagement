using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<bool> ExistsByNameAsync(string name);
    }
}
