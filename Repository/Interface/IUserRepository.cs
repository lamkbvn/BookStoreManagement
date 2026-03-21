using WebBanHang.Entity;

namespace WebBanHang.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> FindByUsernameAsync(string username);
        Task<bool> ExistsByUsernameAsync(string username);

        Task<User?> FindById(int id);

        Task<List<User>> GetAll();

        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
