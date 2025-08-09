using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class LoginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginModel",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "LoginModel",
                newName: "Id");
        }
    }
}
