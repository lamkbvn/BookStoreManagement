using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDiscountAndFinalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Orders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DiscountAmount", "FinalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEOE2ega9OA4hS6ssmpzDmshtb0UJ+HMGV6na6CTNgh087YjhaIk77qKeU+QvB+HG8g==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAENo+S0UGvREsQYoWEpAUkBi8XbtC1W0HUlmaFGAzQTt3WAr/mSTQG2WuhDhpAapzew==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEE+I/Ns21CXCqleq0jGwpbHTV3eWHnWa2D2y7pKgeA9PLk/eMfcIUHyj5eA6UsXnpg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEGa1GIQ7nJfqd6fuJBlZdkzXeBshHekELNTPuBuQoqm7hsJ6D93LP0998duC6Cd0Rw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEHwVhO45UnZweDFaWKPrUMogupDSh0yLSq+FURGvIpC41rUDmEEqAZQ2SXWbrVxmtQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEGmmiDG5zkafFhmG+mZZkJ9m8bT7A2eWa67xFInSTZO0MooSp7rrcndHw7krGv5Qiw==");
        }
    }
}
