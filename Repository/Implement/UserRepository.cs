using Microsoft.EntityFrameworkCore;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
