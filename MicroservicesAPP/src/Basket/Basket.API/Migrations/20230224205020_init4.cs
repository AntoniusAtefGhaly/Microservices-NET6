using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartItem",
                table: "BasketCartItems");

            migrationBuilder.RenameColumn(
                name: "BasketCartItem",
                table: "BasketCartItems",
                newName: "BasketCart");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCartItems_BasketCartItem",
                table: "BasketCartItems",
                newName: "IX_BasketCartItems_BasketCart");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCart",
                table: "BasketCartItems",
                column: "BasketCart",
                principalTable: "BasketCarts",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCart",
                table: "BasketCartItems");

            migrationBuilder.RenameColumn(
                name: "BasketCart",
                table: "BasketCartItems",
                newName: "BasketCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCartItems_BasketCart",
                table: "BasketCartItems",
                newName: "IX_BasketCartItems_BasketCartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartItem",
                table: "BasketCartItems",
                column: "BasketCartItem",
                principalTable: "BasketCarts",
                principalColumn: "UserName");
        }
    }
}
