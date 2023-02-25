using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "BasketCartUserName",
                table: "BasketCartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketCartItem",
                table: "BasketCartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BasketCarts",
                column: "UserName",
                value: "user1");

            migrationBuilder.InsertData(
                table: "BasketCarts",
                column: "UserName",
                value: "user2");

            migrationBuilder.InsertData(
                table: "BasketCarts",
                column: "UserName",
                value: "user3");

            migrationBuilder.CreateIndex(
                name: "IX_BasketCartItems_BasketCartItem",
                table: "BasketCartItems",
                column: "BasketCartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartItem",
                table: "BasketCartItems",
                column: "BasketCartItem",
                principalTable: "BasketCarts",
                principalColumn: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems",
                column: "BasketCartUserName",
                principalTable: "BasketCarts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartItem",
                table: "BasketCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketCartItems_BasketCartItem",
                table: "BasketCartItems");

            migrationBuilder.DeleteData(
                table: "BasketCarts",
                keyColumn: "UserName",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "BasketCarts",
                keyColumn: "UserName",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "BasketCarts",
                keyColumn: "UserName",
                keyValue: "user3");

            migrationBuilder.DropColumn(
                name: "BasketCartItem",
                table: "BasketCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "BasketCartUserName",
                table: "BasketCartItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems",
                column: "BasketCartUserName",
                principalTable: "BasketCarts",
                principalColumn: "UserName");
        }
    }
}
