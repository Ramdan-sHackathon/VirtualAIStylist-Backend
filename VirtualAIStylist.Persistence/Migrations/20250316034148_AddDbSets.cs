using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualAIStylist.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outfit_AspNetUsers_AccountId",
                table: "Outfit");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_AspNetUsers_AccountId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Wardrobe_WardrobeId",
                table: "Piece");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wardrobe",
                table: "Wardrobe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Piece",
                table: "Piece");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outfit",
                table: "Outfit");

            migrationBuilder.RenameTable(
                name: "Wardrobe",
                newName: "Wardrobes");

            migrationBuilder.RenameTable(
                name: "Piece",
                newName: "Pieces");

            migrationBuilder.RenameTable(
                name: "Outfit",
                newName: "Outfits");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_WardrobeId",
                table: "Pieces",
                newName: "IX_Pieces_WardrobeId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_AccountId",
                table: "Pieces",
                newName: "IX_Pieces_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Outfit_AccountId",
                table: "Outfits",
                newName: "IX_Outfits_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wardrobes",
                table: "Wardrobes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outfits",
                table: "Outfits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Outfits_AspNetUsers_AccountId",
                table: "Outfits",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_AspNetUsers_AccountId",
                table: "Pieces",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Wardrobes_WardrobeId",
                table: "Pieces",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outfits_AspNetUsers_AccountId",
                table: "Outfits");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_AspNetUsers_AccountId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Wardrobes_WardrobeId",
                table: "Pieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wardrobes",
                table: "Wardrobes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outfits",
                table: "Outfits");

            migrationBuilder.RenameTable(
                name: "Wardrobes",
                newName: "Wardrobe");

            migrationBuilder.RenameTable(
                name: "Pieces",
                newName: "Piece");

            migrationBuilder.RenameTable(
                name: "Outfits",
                newName: "Outfit");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_WardrobeId",
                table: "Piece",
                newName: "IX_Piece_WardrobeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_AccountId",
                table: "Piece",
                newName: "IX_Piece_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Outfits_AccountId",
                table: "Outfit",
                newName: "IX_Outfit_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wardrobe",
                table: "Wardrobe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Piece",
                table: "Piece",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outfit",
                table: "Outfit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Outfit_AspNetUsers_AccountId",
                table: "Outfit",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_AspNetUsers_AccountId",
                table: "Piece",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Wardrobe_WardrobeId",
                table: "Piece",
                column: "WardrobeId",
                principalTable: "Wardrobe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
