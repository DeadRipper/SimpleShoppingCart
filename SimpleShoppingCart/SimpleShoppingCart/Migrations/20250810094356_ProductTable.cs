using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class ProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "ShopModel");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "ShopModel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShopModel",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ShopModel",
                newName: "ProductName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ShopModel",
                type: "decimal(18,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ShopModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "ShopModel",
                newName: "Title");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ShopModel",
                type: "decimal(14,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "ShopModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "ShopModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
