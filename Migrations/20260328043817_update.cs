using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ImportReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMPWGn3KttH0wGHygAewudbaa8TUGqYlx2q3vs/eo4GU2720MLfSpMqDK+gehc9zpA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEHf4zvAbIhF5UDEKCa9zCUjz2zM9uVeKE6h8WM4Yw8L3W02sGUo0uowp7fLlUJuGXA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAECwh7YdqgnKayERI2nSlWPII32RBkwzVbVyI92jj+h9aHJke1jI7TpyTGEeWZtda1Q==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ImportReceipts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEBVPM2afYP5PxQujYrKVXp7nLbD+2Y84VT1coeWLEVIf3uJf4RE7G6bUmHLgtMiPDw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEDPxzr/wzE3PhsjwuYT1NpUKoxxaP6n8ivkcsorrOxK34nOXUvql79S4XPf5fToAxg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEBl0DGTeCao9JdbRFmkIYYi0CesHzuM8lsMu96EvIzS1XIXYAB+WLNPd/QWTn0vPiQ==");
        }
    }
}
