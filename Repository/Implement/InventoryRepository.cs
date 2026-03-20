using Microsoft.EntityFrameworkCore;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<List<Inventory>> GetAllAsync()
        {
            return await _context.Inventories
                .AsNoTracking()
                .Include(i => i.Product)
                .OrderByDescending(i => i.Id)
                .ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _context.Inventories
                .AsNoTracking()
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            return await _context.Inventories
                .AsNoTracking()
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.Inventories.AnyAsync(i => i.Id == id);
        }

        public async Task<bool> ExistsByProductIdAsync(int productId)
        {
            return await _context.Inventories.AnyAsync(i => i.ProductId == productId);
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task DeleteAsync(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
