using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImportReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImportDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportReceipts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportReceipts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PromotionId = table.Column<int>(type: "int", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImportReceiptItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ImportReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceiptItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportReceiptItems_ImportReceipts_ImportReceiptId",
                        column: x => x.ImportReceiptId,
                        principalTable: "ImportReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportReceiptItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Tiểu thuyết" },
                    { 2, "", "Khoa học" },
                    { 3, "", "Kinh tế" },
                    { 4, "", "Thiếu nhi" },
                    { 5, "", "Lịch sử" },
                    { 6, "", "Tâm lý" },
                    { 7, "", "Văn học" },
                    { 8, "", "Giáo dục" },
                    { 9, "", "Ngoại ngữ" },
                    { 10, "", "Công nghệ" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreateAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Quận 1, TP. Hồ Chí Minh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvana@gmail.com", "Nguyễn Văn A", "0901000001" },
                    { 2, "Quận 3, TP. Hồ Chí Minh", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthib@gmail.com", "Trần Thị B", "0901000002" },
                    { 3, "Quận 5, TP. Hồ Chí Minh", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanc@gmail.com", "Lê Văn C", "0901000003" },
                    { 4, "Quận 7, TP. Hồ Chí Minh", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "phamthid@gmail.com", "Phạm Thị D", "0901000004" },
                    { 5, "Quận Bình Thạnh, TP. Hồ Chí Minh", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoangvane@gmail.com", "Hoàng Văn E", "0901000005" },
                    { 6, "Quận Gò Vấp, TP. Hồ Chí Minh", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "dothif@gmail.com", "Đỗ Thị F", "0901000006" },
                    { 7, "Quận Tân Bình, TP. Hồ Chí Minh", new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuvang@gmail.com", "Vũ Văn G", "0901000007" },
                    { 8, "Quận Thủ Đức, TP. Hồ Chí Minh", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "buithih@gmail.com", "Bùi Thị H", "0901000008" },
                    { 9, "Quận 12, TP. Hồ Chí Minh", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "phanvani@gmail.com", "Phan Văn I", "0901000009" },
                    { 10, "Huyện Bình Chánh, TP. Hồ Chí Minh", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "dangthik@gmail.com", "Đặng Thị K", "0901000010" }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "Description", "DiscountPercentage", "EndDate", "IsActive", "MaximumDiscountAmount", "StartDate" },
                values: new object[,]
                {
                    { 1, "SALE10", "Giảm 10% cho tất cả sản phẩm", 10m, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100000m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "SALE20", "Giảm 20% tối đa 200k", 20m, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 200000m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "NEWUSER", "Ưu đãi cho người dùng mới", 15m, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 150000m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "BLACKFRIDAY", "Khuyến mãi Black Friday", 30m, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 500000m, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "EXPIRED", "Mã đã hết hạn để test logic", 5m, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 50000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NXB Trẻ" },
                    { 2, "NXB Kim Đồng" },
                    { 3, "NXB Giáo Dục" },
                    { 4, "NXB Lao Động" },
                    { 5, "NXB Văn Học" },
                    { 6, "NXB Thế Giới" },
                    { 7, "NXB Khoa Học" },
                    { 8, "NXB Tổng Hợp" },
                    { 9, "NXB Phụ Nữ" },
                    { 10, "NXB Thanh Niên" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Admin System", "AQAAAAIAAYagAAAAEDk0FDU9g7wJCeFaPmVW0q8WZnmZuDlRBDClTC+ieHcgJe+xAYU5OP80vauhNMTX+A==", 0, "admin01" },
                    { 2, "Nhân viên 1", "AQAAAAIAAYagAAAAEHjdPSHGH8K6K/dfVQjBZ4RaAsboNKPz2vNLFucgZBQLSk4zNsXkOCzNsq9RwSrbYw==", 1, "staff01" },
                    { 3, "Nhân viên 2", "AQAAAAIAAYagAAAAEA+hqiri/9fQhpGIFbstNQbptGcOsuyn2mUf7gRX6RHIHgNpQfE0bEvxeOiymcg9KA==", 1, "staff02" }
                });

            migrationBuilder.InsertData(
                table: "ImportReceipts",
                columns: new[] { "Id", "ImportDate", "Status", "SupplierId", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 500000m, 1 },
                    { 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 300000m, 2 },
                    { 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, 450000m, 3 },
                    { 4, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 220000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DiscountAmount", "FinalPrice", "OrderDate", "PromotionId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 10000m, 165000m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, 2, 20000m, 260000m, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 3, 3, 0m, 270000m, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3 },
                    { 4, 4, 15000m, 95000m, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 5, 5, 10000m, 280000m, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 6, 6, 0m, 130000m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3 },
                    { 7, 7, 20000m, 140000m, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 1, 4, "Dế Mèn Phiêu Lưu Ký", 50000m, 2 },
                    { 2, 1, "Nhà Giả Kim", 75000m, 1 },
                    { 3, 5, "Sapiens", 120000m, 6 },
                    { 4, 3, "Cha Giàu Cha Nghèo", 90000m, 4 },
                    { 5, 6, "Đắc Nhân Tâm", 80000m, 9 },
                    { 6, 1, "Harry Potter 1", 110000m, 5 },
                    { 7, 10, "Clean Code", 150000m, 7 },
                    { 8, 9, "English Grammar", 70000m, 3 },
                    { 9, 6, "Tư Duy Nhanh Và Chậm", 130000m, 6 },
                    { 10, 10, "Lập Trình C#", 160000m, 7 }
                });

            migrationBuilder.InsertData(
                table: "ImportReceiptItems",
                columns: new[] { "Id", "ImportReceiptId", "ProductId", "Quantity", "UnitCost" },
                values: new object[,]
                {
                    { 1, 1, 2, 10, 30000m },
                    { 2, 1, 1, 5, 20000m },
                    { 3, 2, 6, 5, 50000m },
                    { 4, 2, 4, 3, 50000m },
                    { 5, 3, 7, 3, 100000m },
                    { 6, 3, 10, 2, 75000m },
                    { 7, 4, 3, 2, 100000m },
                    { 8, 4, 5, 1, 20000m }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 2, 2, 130 },
                    { 3, 3, 80 },
                    { 4, 4, 70 },
                    { 5, 5, 90 },
                    { 6, 6, 50 },
                    { 7, 7, 40 },
                    { 8, 8, 100 },
                    { 9, 9, 70 },
                    { 10, 10, 30 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 50000m },
                    { 2, 1, 2, 1, 75000m },
                    { 3, 2, 3, 1, 120000m },
                    { 4, 2, 5, 2, 80000m },
                    { 5, 3, 4, 3, 90000m },
                    { 6, 4, 6, 1, 110000m },
                    { 7, 5, 7, 1, 150000m },
                    { 8, 5, 8, 2, 70000m },
                    { 9, 6, 9, 1, 130000m },
                    { 10, 7, 10, 1, 160000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptItems_ImportReceiptId",
                table: "ImportReceiptItems",
                column: "ImportReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptItems_ProductId",
                table: "ImportReceiptItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipts_SupplierId",
                table: "ImportReceipts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipts_UserId",
                table: "ImportReceipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromotionId",
                table: "Orders",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportReceiptItems");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ImportReceipts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
