using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItem_BasketCarts_BasketCartUserName",
                table: "BasketCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketCartItem",
                table: "BasketCartItem");

            migrationBuilder.RenameTable(
                name: "BasketCartItem",
                newName: "BasketCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCartItem_BasketCartUserName",
                table: "BasketCartItems",
                newName: "IX_BasketCartItems_BasketCartUserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketCartItems",
                table: "BasketCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems",
                column: "BasketCartUserName",
                principalTable: "BasketCarts",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketCartItems",
                table: "BasketCartItems");

            migrationBuilder.RenameTable(
                name: "BasketCartItems",
                newName: "BasketCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCartItems_BasketCartUserName",
                table: "BasketCartItem",
                newName: "IX_BasketCartItem_BasketCartUserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketCartItem",
                table: "BasketCartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItem_BasketCarts_BasketCartUserName",
                table: "BasketCartItem",
                column: "BasketCartUserName",
                principalTable: "BasketCarts",
                principalColumn: "UserName");
        }
    }
}
