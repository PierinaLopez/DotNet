using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Album_AlbumID",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_AlbumID",
                table: "CartItem",
                newName: "IX_CartItem_AlbumID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "CartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Album_AlbumID",
                table: "CartItem",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Album_AlbumID",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_AlbumID",
                table: "Cart",
                newName: "IX_Cart_AlbumID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "CartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Album_AlbumID",
                table: "Cart",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
