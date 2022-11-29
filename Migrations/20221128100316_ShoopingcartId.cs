using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NollyTickets.Ng.Migrations
{
    /// <inheritdoc />
    public partial class ShoopingcartId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCart",
                table: "ShoppingCartItems",
                newName: "ShopppingCartId");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ShopppingCartId",
                table: "ShoppingCartItems",
                newName: "ShoppingCart");
        }
    }
}
