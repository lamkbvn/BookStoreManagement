namespace WebBanHang.SeedData;

using global::WebBanHang.Entity;
using global::WebBanHang.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class DbSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {

        var passwordHasher = new PasswordHasher<User>();
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
            // Lưu ý: hệ thống hiện cộng tồn kho ngay khi tạo phiếu nhập.
            // Vì vậy tồn kho seed bên dưới đã bao gồm các dòng hàng của phiếu nhập seed ở phần sau.
            new Inventory { Id = 1, ProductId = 1, Quantity = 100 },
            new Inventory { Id = 2, ProductId = 2, Quantity = 130 },
            new Inventory { Id = 3, ProductId = 3, Quantity = 80 },
            new Inventory { Id = 4, ProductId = 4, Quantity = 70 },
            new Inventory { Id = 5, ProductId = 5, Quantity = 90 },
            new Inventory { Id = 6, ProductId = 6, Quantity = 50 },
            new Inventory { Id = 7, ProductId = 7, Quantity = 40 },
            new Inventory { Id = 8, ProductId = 8, Quantity = 100 },
            new Inventory { Id = 9, ProductId = 9, Quantity = 70 },
            new Inventory { Id = 10, ProductId = 10, Quantity = 30 }
        );

        // ===== CUSTOMER =====
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Name = "Nguyễn Văn A",
                Email = "nguyenvana@gmail.com",
                Phone = "0901000001",
                Address = "Quận 1, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 1)
            },
            new Customer
            {
                Id = 2,
                Name = "Trần Thị B",
                Email = "tranthib@gmail.com",
                Phone = "0901000002",
                Address = "Quận 3, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 2)
            },
            new Customer
            {
                Id = 3,
                Name = "Lê Văn C",
                Email = "levanc@gmail.com",
                Phone = "0901000003",
                Address = "Quận 5, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 3)
            },
            new Customer
            {
                Id = 4,
                Name = "Phạm Thị D",
                Email = "phamthid@gmail.com",
                Phone = "0901000004",
                Address = "Quận 7, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 4)
            },
            new Customer
            {
                Id = 5,
                Name = "Hoàng Văn E",
                Email = "hoangvane@gmail.com",
                Phone = "0901000005",
                Address = "Quận Bình Thạnh, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 5)
            },
            new Customer
            {
                Id = 6,
                Name = "Đỗ Thị F",
                Email = "dothif@gmail.com",
                Phone = "0901000006",
                Address = "Quận Gò Vấp, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 6)
            },
            new Customer
            {
                Id = 7,
                Name = "Vũ Văn G",
                Email = "vuvang@gmail.com",
                Phone = "0901000007",
                Address = "Quận Tân Bình, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 7)
            },
            new Customer
            {
                Id = 8,
                Name = "Bùi Thị H",
                Email = "buithih@gmail.com",
                Phone = "0901000008",
                Address = "Quận Thủ Đức, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 8)
            },
            new Customer
            {
                Id = 9,
                Name = "Phan Văn I",
                Email = "phanvani@gmail.com",
                Phone = "0901000009",
                Address = "Quận 12, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 9)
            },
            new Customer
            {
                Id = 10,
                Name = "Đặng Thị K",
                Email = "dangthik@gmail.com",
                Phone = "0901000010",
                Address = "Huyện Bình Chánh, TP. Hồ Chí Minh",
                CreateAt = new DateTime(2025, 1, 10)
            }
        );


        // ===== USER =====

        var admin = new User
        {
            Id = 1,
            Fullname = "Admin System",
            Username = "admin01",
            Role = Role.Admin,
            Password = "password",
        };
        admin.Password = passwordHasher.HashPassword(admin, "123456");

        var staff1 = new User
        {
            Id = 2,
            Fullname = "Nhân viên 1",
            Username = "staff01",
            Role = Role.Staff,
            Password = "password",
        };
        staff1.Password = passwordHasher.HashPassword(staff1, "123456");

        var staff2 = new User
        {
            Id = 3,
            Fullname = "Nhân viên 2",
            Username = "staff02",
            Role = Role.Staff,
            Password = "password"
        };
        staff2.Password = passwordHasher.HashPassword(staff2, "123456");

        modelBuilder.Entity<User>().HasData(admin, staff1, staff2);


        //==== PROMOTION ====
        modelBuilder.Entity<Promotion>().HasData(
        new Promotion
        {
            Id = 1,
            Code = "SALE10",
            Description = "Giảm 10% cho tất cả sản phẩm",
            DiscountPercentage = 10,
            MaximumDiscountAmount = 100000,
            StartDate = new DateTime(2025, 1, 1),
            EndDate = new DateTime(2025, 12, 31),
            IsActive = true
        },
        new Promotion
        {
            Id = 2,
            Code = "SALE20",
            Description = "Giảm 20% tối đa 200k",
            DiscountPercentage = 20,
            MaximumDiscountAmount = 200000,
            StartDate = new DateTime(2025, 2, 1),
            EndDate = new DateTime(2025, 6, 30),
            IsActive = true
        },
        new Promotion
        {
            Id = 3,
            Code = "NEWUSER",
            Description = "Ưu đãi cho người dùng mới",
            DiscountPercentage = 15,
            MaximumDiscountAmount = 150000,
            StartDate = new DateTime(2025, 1, 1),
            EndDate = new DateTime(2025, 12, 31),
            IsActive = true
        },
        new Promotion
        {
            Id = 4,
            Code = "BLACKFRIDAY",
            Description = "Khuyến mãi Black Friday",
            DiscountPercentage = 30,
            MaximumDiscountAmount = 500000,
            StartDate = new DateTime(2025, 11, 25),
            EndDate = new DateTime(2025, 11, 30),
            IsActive = true
        },
        new Promotion
        {
            Id = 5,
            Code = "EXPIRED",
            Description = "Mã đã hết hạn để test logic",
            DiscountPercentage = 5,
            MaximumDiscountAmount = 50000,
            StartDate = new DateTime(2024, 1, 1),
            EndDate = new DateTime(2024, 12, 31),
            IsActive = false
        }
    );

        // ===== ORDER =====
        modelBuilder.Entity<Order>().HasData(
    new Order
    {
        Id = 1,
        CustomerId = 1,
        UserId = 1,
        PromotionId = 1,
        DiscountAmount = 10000,
        FinalPrice = 165000,
        Status = OrderStatus.Paid,
        OrderDate = new DateTime(2025, 1, 5)
    },
    new Order
    {
        Id = 2,
        CustomerId = 2,
        UserId = 2,
        PromotionId = 2,
        DiscountAmount = 20000,
        FinalPrice = 260000,
        Status = OrderStatus.Paid,
        OrderDate = new DateTime(2025, 1, 6)
    },
    new Order
    {
        Id = 3,
        CustomerId = 3,
        UserId = 3,
        PromotionId = null,
        DiscountAmount = 0,
        FinalPrice = 270000,
        Status = OrderStatus.Pending,
        OrderDate = new DateTime(2025, 1, 7)
    },
    new Order
    {
        Id = 4,
        CustomerId = 4,
        UserId = 1,
        PromotionId = 3,
        DiscountAmount = 15000,
        FinalPrice = 95000,
        Status = OrderStatus.Cancelled,
        OrderDate = new DateTime(2025, 1, 8)
    },
    new Order
    {
        Id = 5,
        CustomerId = 5,
        UserId = 2,
        PromotionId = 1,
        DiscountAmount = 10000,
        FinalPrice = 280000,
        Status = OrderStatus.Paid,
        OrderDate = new DateTime(2025, 1, 9)
    },
    new Order
    {
        Id = 6,
        CustomerId = 6,
        UserId = 3,
        PromotionId = null,
        DiscountAmount = 0,
        FinalPrice = 130000,
        Status = OrderStatus.Pending,
        OrderDate = new DateTime(2025, 1, 10)
    },
    new Order
    {
        Id = 7,
        CustomerId = 7,
        UserId = 1,
        PromotionId = 2,
        DiscountAmount = 20000,
        FinalPrice = 140000,
        Status = OrderStatus.Paid,
        OrderDate = new DateTime(2025, 1, 11)
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


        modelBuilder.Entity<ImportReceipt>().HasData(
            new ImportReceipt
            {
                Id = 1,
                ImportDate = new DateTime(2025, 1, 2),
                SupplierId = 1,
                UserId = 1,
                TotalAmount = 500000,
                Status = ImportReceiptStatus.Approved
            },
            new ImportReceipt
            {
                Id = 2,
                ImportDate = new DateTime(2025, 1, 3),
                SupplierId = 2,
                UserId = 2,
                TotalAmount = 300000,
                Status = ImportReceiptStatus.Approved
            },
            new ImportReceipt
            {
                Id = 3,
                ImportDate = new DateTime(2025, 1, 4),
                SupplierId = 7,
                UserId = 3,
                TotalAmount = 450000,
                Status = ImportReceiptStatus.Pending
            },
            new ImportReceipt
            {
                Id = 4,
                ImportDate = new DateTime(2025, 1, 5),
                SupplierId = 5,
                UserId = 1,
                TotalAmount = 220000,
                Status = ImportReceiptStatus.Approved
            }
        );


        modelBuilder.Entity<ImportReceiptItem>().HasData(
            // Receipt 1
            new ImportReceiptItem { Id = 1, ImportReceiptId = 1, ProductId = 2, Quantity = 10, UnitCost = 30000 },
            new ImportReceiptItem { Id = 2, ImportReceiptId = 1, ProductId = 1, Quantity = 5, UnitCost = 20000 },

            // Receipt 2
            new ImportReceiptItem { Id = 3, ImportReceiptId = 2, ProductId = 6, Quantity = 5, UnitCost = 50000 },
            new ImportReceiptItem { Id = 4, ImportReceiptId = 2, ProductId = 4, Quantity = 3, UnitCost = 50000 },

            // Receipt 3
            new ImportReceiptItem { Id = 5, ImportReceiptId = 3, ProductId = 7, Quantity = 3, UnitCost = 100000 },
            new ImportReceiptItem { Id = 6, ImportReceiptId = 3, ProductId = 10, Quantity = 2, UnitCost = 75000 },

            // Receipt 4
            new ImportReceiptItem { Id = 7, ImportReceiptId = 4, ProductId = 3, Quantity = 2, UnitCost = 100000 },
            new ImportReceiptItem { Id = 8, ImportReceiptId = 4, ProductId = 5, Quantity = 1, UnitCost = 20000 }
        );
    }
}




