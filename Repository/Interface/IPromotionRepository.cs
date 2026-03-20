using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IPromotionRepository
    {
        Task<Promotion> AddAsync(Promotion promotion);
        Task<List<Promotion>> GetAllAsync();
        Task<Promotion?> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<Promotion> UpdateAsync(Promotion promotion);
        Task DeleteAsync(Promotion promotion);
    }
}
