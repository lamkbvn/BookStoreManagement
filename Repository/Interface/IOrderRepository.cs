using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<Order> UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }
}
