using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class InitialMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypeModels_PropertyModels_PropertyModelId",
                table: "PropertyTypeModels");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTypeModels_PropertyModelId",
                table: "PropertyTypeModels");

            migrationBuilder.DropColumn(
                name: "PropertyID",
                table: "PropertyTypeModels");

            migrationBuilder.DropColumn(
                name: "PropertyModelId",
                table: "PropertyTypeModels");

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeID",
                table: "PropertyModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PropertyTypeModelID",
                table: "PropertyModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyModels_PropertyTypeModelID",
                table: "PropertyModels",
                column: "PropertyTypeModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModels_PropertyTypeModels_PropertyTypeModelID",
                table: "PropertyModels",
                column: "PropertyTypeModelID",
                principalTable: "PropertyTypeModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModels_PropertyTypeModels_PropertyTypeModelID",
                table: "PropertyModels");

            migrationBuilder.DropIndex(
                name: "IX_PropertyModels_PropertyTypeModelID",
                table: "PropertyModels");

            migrationBuilder.DropColumn(
                name: "PropertyTypeID",
                table: "PropertyModels");

            migrationBuilder.DropColumn(
                name: "PropertyTypeModelID",
                table: "PropertyModels");

            migrationBuilder.AddColumn<int>(
                name: "PropertyID",
                table: "PropertyTypeModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PropertyModelId",
                table: "PropertyTypeModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypeModels_PropertyModelId",
                table: "PropertyTypeModels",
                column: "PropertyModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypeModels_PropertyModels_PropertyModelId",
                table: "PropertyTypeModels",
                column: "PropertyModelId",
                principalTable: "PropertyModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
