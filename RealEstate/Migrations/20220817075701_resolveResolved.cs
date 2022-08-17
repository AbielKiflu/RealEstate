using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class resolveResolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_PropertyType_PropertyID",
                table: "Favorite");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Property_PropertyID",
                table: "Favorite",
                column: "PropertyID",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Property_PropertyID",
                table: "Favorite");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_PropertyType_PropertyID",
                table: "Favorite",
                column: "PropertyID",
                principalTable: "PropertyType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
