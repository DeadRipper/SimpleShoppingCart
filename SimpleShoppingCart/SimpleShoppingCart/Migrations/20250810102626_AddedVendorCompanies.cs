using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class AddedVendorCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "ShopModel",
                newName: "ProductTitle");

            migrationBuilder.AddColumn<int>(
                name: "FirmBadge",
                table: "ShopModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductSubTitle",
                table: "ShopModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductWeight",
                table: "ShopModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmBadge",
                table: "ShopModel");

            migrationBuilder.DropColumn(
                name: "ProductSubTitle",
                table: "ShopModel");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "ShopModel");

            migrationBuilder.RenameColumn(
                name: "ProductTitle",
                table: "ShopModel",
                newName: "ProductName");
        }
    }
}
