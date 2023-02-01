using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class updatestopage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Page",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Page_ImageId",
                table: "Page",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page",
                column: "ImageId",
                principalTable: "BinaryFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_BinaryFile_ImageId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_ImageId",
                table: "Page");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Page",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
