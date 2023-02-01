using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class AddParentPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Page",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Page",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Page",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentPageId",
                table: "Page",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page",
                column: "ImageId",
                principalTable: "BinaryFile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ParentPageId",
                table: "Page");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Page",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page",
                column: "ImageId",
                principalTable: "BinaryFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
