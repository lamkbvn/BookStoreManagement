namespace WebBanHang.SeedData;

using global::WebBanHang.Entity;
using global::WebBanHang.Enum;
using Microsoft.EntityFrameworkCore;

public static class DbSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // ===== CATEGORY =====
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Tiểu thuyết" },
            new Category { Id = 2, Name = "Khoa học" },
            new Category { Id = 3, Name = "Kinh tế" },
            new Category { Id = 4, Name = "Thiếu nhi" },
            new Category { Id = 5, Name = "Lịch sử" },
            new Category { Id = 6, Name = "Tâm lý" },
            new Category { Id = 7, Name = "Văn học" },
            new Category { Id = 8, Name = "Giáo dục" },
            new Category { Id = 9, Name = "Ngoại ngữ" },
            new Category { Id = 10, Name = "Công nghệ" }
        );

        // ===== SUPPLIER =====
        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { Id = 1, Name = "NXB Trẻ" },
            new Supplier { Id = 2, Name = "NXB Kim Đồng" },
            new Supplier { Id = 3, Name = "NXB Giáo Dục" },
            new Supplier { Id = 4, Name = "NXB Lao Động" },
            new Supplier { Id = 5, Name = "NXB Văn Học" },
            new Supplier { Id = 6, Name = "NXB Thế Giới" },
            new Supplier { Id = 7, Name = "NXB Khoa Học" },
            new Supplier { Id = 8, Name = "NXB Tổng Hợp" },
            new Supplier { Id = 9, Name = "NXB Phụ Nữ" },
            new Supplier { Id = 10, Name = "NXB Thanh Niên" }
        );

        // ===== PRODUCT (BOOK) =====
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Dế Mèn Phiêu Lưu Ký", Price = 50000, CategoryId = 4, SupplierId = 2 },
            new Product { Id = 2, Name = "Nhà Giả Kim", Price = 75000, CategoryId = 1, SupplierId = 1 },
            new Product { Id = 3, Name = "Sapiens", Price = 120000, CategoryId = 5, SupplierId = 6 },
            new Product { Id = 4, Name = "Cha Giàu Cha Nghèo", Price = 90000, CategoryId = 3, SupplierId = 4 },
            new Product { Id = 5, Name = "Đắc Nhân Tâm", Price = 80000, CategoryId = 6, SupplierId = 9 },
            new Product { Id = 6, Name = "Harry Potter 1", Price = 110000, CategoryId = 1, SupplierId = 5 },
            new Product { Id = 7, Name = "Clean Code", Price = 150000, CategoryId = 10, SupplierId = 7 },
            new Product { Id = 8, Name = "English Grammar", Price = 70000, CategoryId = 9, SupplierId = 3 },
            new Product { Id = 9, Name = "Tư Duy Nhanh Và Chậm", Price = 130000, CategoryId = 6, SupplierId = 6 },
            new Product { Id = 10, Name = "Lập Trình C#", Price = 160000, CategoryId = 10, SupplierId = 7 }
        );

        // ===== INVENTORY =====
        modelBuilder.Entity<Inventory>().HasData(
            new Inventory { Id = 1, ProductId = 1, Quantity = 100 },
            new Inventory { Id = 2, ProductId = 2, Quantity = 80 },
            new Inventory { Id = 3, ProductId = 3, Quantity = 60 },
            new Inventory { Id = 4, ProductId = 4, Quantity = 70 },
            new Inventory { Id = 5, ProductId = 5, Quantity = 90 },
            new Inventory { Id = 6, ProductId = 6, Quantity = 50 },
            new Inventory { Id = 7, ProductId = 7, Quantity = 40 },
            new Inventory { Id = 8, ProductId = 8, Quantity = 100 },
            new Inventory { Id = 9, ProductId = 9, Quantity = 65 },
            new Inventory { Id = 10, ProductId = 10, Quantity = 30 }
        );

        // ===== CUSTOMER =====
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Nguyễn Văn A", CreateAt = new DateTime(2025, 1, 1) },
            new Customer { Id = 2, Name = "Trần Thị B", CreateAt = new DateTime(2025, 1, 2) },
            new Customer { Id = 3, Name = "Lê Văn C", CreateAt = new DateTime(2025, 1, 3) },
            new Customer { Id = 4, Name = "Phạm Thị D", CreateAt = new DateTime(2025, 1, 4) },
            new Customer { Id = 5, Name = "Hoàng Văn E", CreateAt = new DateTime(2025, 1, 5) },
            new Customer { Id = 6, Name = "Đỗ Thị F", CreateAt = new DateTime(2025, 1, 6) },
            new Customer { Id = 7, Name = "Vũ Văn G", CreateAt = new DateTime(2025, 1, 7) },
            new Customer { Id = 8, Name = "Bùi Thị H", CreateAt = new DateTime(2025, 1, 8) },
            new Customer { Id = 9, Name = "Phan Văn I", CreateAt = new DateTime(2025, 1, 9) },
            new Customer { Id = 10, Name = "Đặng Thị K", CreateAt = new DateTime(2025, 1, 10) }
        );

        // ===== PROMOTION =====
        modelBuilder.Entity<Promotion>().HasData(
            new Promotion { Id = 1, Code = "SALE10", DiscountPercent = 10, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 2, Code = "SALE15", DiscountPercent = 15, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 3, Code = "SALE20", DiscountPercent = 20, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 4, Code = "BOOK5", DiscountPercent = 5, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 5, Code = "BOOK7", DiscountPercent = 7, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 6, Code = "BOOK12", DiscountPercent = 12, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 7, Code = "VIP20", DiscountPercent = 20, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 8, Code = "VIP25", DiscountPercent = 25, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31) },
            new Promotion { Id = 9, Code = "TET30", DiscountPercent = 30, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 2, 15) },
            new Promotion { Id = 10, Code = "SUMMER15", DiscountPercent = 15, StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 8, 31) }
        );

        // ===== USER =====
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Fullname = "Admin System", Username = "admin", Password = "123456", Role = Role.Admin },
            new User { Id = 2, Fullname = "Nhân viên 1", Username = "staff1", Password = "123456", Role = Role.Staff },
            new User { Id = 3, Fullname = "Nhân viên 2", Username = "staff2", Password = "123456", Role = Role.Staff },
            new User { Id = 4, Fullname = "Khách 1", Username = "cus1", Password = "123456", Role = Role.Customer, CustomerId = 1 },
            new User { Id = 5, Fullname = "Khách 2", Username = "cus2", Password = "123456", Role = Role.Customer, CustomerId = 2 },
            new User { Id = 6, Fullname = "Khách 3", Username = "cus3", Password = "123456", Role = Role.Customer, CustomerId = 3 },
            new User { Id = 7, Fullname = "Khách 4", Username = "cus4", Password = "123456", Role = Role.Customer, CustomerId = 4 },
            new User { Id = 8, Fullname = "Khách 5", Username = "cus5", Password = "123456", Role = Role.Customer, CustomerId = 5 },
            new User { Id = 9, Fullname = "Khách 6", Username = "cus6", Password = "123456", Role = Role.Customer, CustomerId = 6 },
            new User { Id = 10, Fullname = "Khách 7", Username = "cus7", Password = "123456", Role = Role.Customer, CustomerId = 7 }
        );

        // ===== ORDER =====
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                CustomerId = 1,
                UserId = 1,
                PromotionId = 1,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 5)
            },
            new Order
            {
                Id = 2,
                CustomerId = 2,
                UserId = 2,
                PromotionId = 2,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 6)
            },
            new Order
            {
                Id = 3,
                CustomerId = 3,
                UserId = 3,
                PromotionId = null,
                Status = OrderStatus.Pending,
                OrderDate = new DateTime(2025, 1, 7)
            },
            new Order
            {
                Id = 4,
                CustomerId = 4,
                UserId = 4,
                PromotionId = 3,
                Status = OrderStatus.Cancelled,
                OrderDate = new DateTime(2025, 1, 8)
            },
            new Order
            {
                Id = 5,
                CustomerId = 5,
                UserId = 5,
                PromotionId = 4,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 9)
            },
            new Order
            {
                Id = 6,
                CustomerId = 6,
                UserId = 6,
                PromotionId = null,
                Status = OrderStatus.Pending,
                OrderDate = new DateTime(2025, 1, 10)
            },
            new Order
            {
                Id = 7,
                CustomerId = 7,
                UserId = 7,
                PromotionId = 5,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 11)
            },
            new Order
            {
                Id = 8,
                CustomerId = 8,
                UserId = 8,
                PromotionId = 6,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 12)
            },
            new Order
            {
                Id = 9,
                CustomerId = 9,
                UserId = 9,
                PromotionId = null,
                Status = OrderStatus.Pending,
                OrderDate = new DateTime(2025, 1, 13)
            },
            new Order
            {
                Id = 10,
                CustomerId = 10,
                UserId = 10,
                PromotionId = 7,
                Status = OrderStatus.Paid,
                OrderDate = new DateTime(2025, 1, 14)
            }
        );


        // ===== ORDER ITEM =====
        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 50000 },
            new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 75000 },

            new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 120000 },
            new OrderItem { Id = 4, OrderId = 2, ProductId = 5, Quantity = 2, UnitPrice = 80000 },

            new OrderItem { Id = 5, OrderId = 3, ProductId = 4, Quantity = 3, UnitPrice = 90000 },

            new OrderItem { Id = 6, OrderId = 4, ProductId = 6, Quantity = 1, UnitPrice = 110000 },

            new OrderItem { Id = 7, OrderId = 5, ProductId = 7, Quantity = 1, UnitPrice = 150000 },
            new OrderItem { Id = 8, OrderId = 5, ProductId = 8, Quantity = 2, UnitPrice = 70000 },

            new OrderItem { Id = 9, OrderId = 6, ProductId = 9, Quantity = 1, UnitPrice = 130000 },

            new OrderItem { Id = 10, OrderId = 7, ProductId = 10, Quantity = 1, UnitPrice = 160000 }
        );
    }
}




