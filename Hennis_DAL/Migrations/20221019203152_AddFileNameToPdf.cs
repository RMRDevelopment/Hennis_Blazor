using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class AddFileNameToPdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BinaryFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BinaryFile");
        }
    }
}
