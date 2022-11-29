using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NollyTickets.Ng.Migrations
{
    /// <inheritdoc />
    public partial class correctedtheOrderitemDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MoveId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MoveId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MoveId",
                table: "OrderItems",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MoveId",
                table: "OrderItems",
                column: "MoveId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
