using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMVnVx2ReivGfWTDoQSUSy8ig2nIs3P2RdlkNJZW9tp32xdBWeKFDn7fydAExp0GEA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEIDV7CbFPzkmFTzMVLGZbAANY4wK8uYnwmYgLaTSPvOiVVYfNID/3eOOkoPOJmtWRg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEDjyF0Il0lLSmaI4H4SQSUOPv24TtoqMGQRpAsAIh56GsItQFfozObOC1XY6iDA9QQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEI+Sb6X6E89iolbQ5KT9j4NrZqUcmOaLMp+J4BOTT8sNTJkCQEG+WwNutEsCwjUIQg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAECp0fALDS0QoT9fOUbPJ5S2VrY1qZ5Lf7tWlKtS18y1ZOomYYOCGAXzMVKiXqhYaXQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEOiLSwPj3R2wPprJXEYcrvnWcHLZrbUIzATi/bxFT7pM6rQyTZu4cCxGgcqQv15uFQ==");
        }
    }
}
