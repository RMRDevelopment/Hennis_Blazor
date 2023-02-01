using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class AddParentPageMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Page_ParentPageId",
                table: "Page",
                column: "ParentPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Page_ParentPageId",
                table: "Page",
                column: "ParentPageId",
                principalTable: "Page",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Page_ParentPageId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_ParentPageId",
                table: "Page");
        }
    }
}
