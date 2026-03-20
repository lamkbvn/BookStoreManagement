using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class AddMaximumDiscountAmountToPromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaximumDiscountAmount",
                table: "Promotions",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEH5szNlQ18SOt+xzydG9vmu0MANEAbOa4n7/IBF3iImLEUm2FAP9OLUKbLDEvpdMaA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEIgaw7bLwlyxNDLOlNFb4BOF78aQSaQW7k6wfMeBNbT2PiLRsaluOwp5cqXa/FL3kg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEFuhauWS5GcTe+uRCaNI+zHafzTRuhDHnFL2wNQNrQs9sjg56vuyx+qP5OJzJzk5JA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumDiscountAmount",
                table: "Promotions");

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
    }
}
