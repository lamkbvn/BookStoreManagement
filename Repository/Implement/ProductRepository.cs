using Microsoft.EntityFrameworkCore;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Repository.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product, int initialQuantity)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var inventory = new Inventory
            {
                ProductId = product.Id,
                Quantity = initialQuantity
            };

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Inventory)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetTrackedByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);
        }

        public async Task<bool> ExistsByNameExceptIdAsync(string name, int exceptId)
        {
            return await _context.Products.AnyAsync(p => p.Name == name && p.Id != exceptId);
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> SupplierExistsAsync(int supplierId)
        {
            return await _context.Suppliers.AnyAsync(s => s.Id == supplierId);
        }

        public async Task<Product> UpdateAsync(Product product, int quantity)
        {
            if (product.Inventory is null)
            {
                var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == product.Id);
                if (inventory is null)
                {
                    inventory = new Inventory { ProductId = product.Id, Quantity = quantity };
                    _context.Inventories.Add(inventory);
                }
                else
                {
                    inventory.Quantity = quantity;
                }
            }
            else
            {
                product.Inventory.Quantity = quantity;
            }

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == product.Id);
            if (inventory is not null)
            {
                _context.Inventories.Remove(inventory);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

