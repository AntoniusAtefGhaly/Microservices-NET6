using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketCartItems_BasketCartUserName",
                table: "BasketCartItems");

            migrationBuilder.DropColumn(
                name: "BasketCartUserName",
                table: "BasketCartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasketCartUserName",
                table: "BasketCartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BasketCartItems_BasketCartUserName",
                table: "BasketCartItems",
                column: "BasketCartUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCartItems_BasketCarts_BasketCartUserName",
                table: "BasketCartItems",
                column: "BasketCartUserName",
                principalTable: "BasketCarts",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
