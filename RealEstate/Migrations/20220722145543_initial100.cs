using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class initial100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_PropertyType_PropertyTypeID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_ApplicationUserID",
                table: "Property");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyTypeID",
                table: "Property",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ApplicationUserID",
                table: "Property",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_PropertyType_PropertyTypeID",
                table: "Property",
                column: "PropertyTypeID",
                principalTable: "PropertyType",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_ApplicationUserID",
                table: "Property",
                column: "ApplicationUserID",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_PropertyType_PropertyTypeID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_ApplicationUserID",
                table: "Property");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyTypeID",
                table: "Property",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ApplicationUserID",
                table: "Property",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_PropertyType_PropertyTypeID",
                table: "Property",
                column: "PropertyTypeID",
                principalTable: "PropertyType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_ApplicationUserID",
                table: "Property",
                column: "ApplicationUserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
