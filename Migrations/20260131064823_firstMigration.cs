using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
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
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "CustomerId", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, null, "Admin System", "123456", 0, "admin" },
                    { 2, null, "Nhân viên 1", "123456", 1, "staff1" },
                    { 3, null, "Nhân viên 2", "123456", 1, "staff2" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 3, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 4, 4, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 5, 5, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 7, 7, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 8, 8, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 9, 9, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 10, 10, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
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
                table: "Inventories",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 2, 2, 80 },
                    { 3, 3, 60 },
                    { 4, 4, 70 },
                    { 5, 5, 90 },
                    { 6, 6, 50 },
                    { 7, 7, 40 },
                    { 8, 8, 100 },
                    { 9, 9, 65 },
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
