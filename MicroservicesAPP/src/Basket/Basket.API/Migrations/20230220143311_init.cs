using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketCarts",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketCarts", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "BasketCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketCartUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketCartItem_BasketCarts_BasketCartUserName",
                        column: x => x.BasketCartUserName,
                        principalTable: "BasketCarts",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketCartItem_BasketCartUserName",
                table: "BasketCartItem",
                column: "BasketCartUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketCartItem");

            migrationBuilder.DropTable(
                name: "BasketCarts");
        }
    }
}
