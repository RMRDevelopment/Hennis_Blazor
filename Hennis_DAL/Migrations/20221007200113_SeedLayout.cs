using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class SeedLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Layout",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Full Width" });

            migrationBuilder.InsertData(
                table: "Layout",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Two Column" });

            migrationBuilder.InsertData(
                table: "LayoutZone",
                columns: new[] { "Id", "LayoutId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Feature" },
                    { 2, 1, "ZoneA" },
                    { 3, 2, "Feature" },
                    { 4, 2, "ZoneA" },
                    { 5, 2, "ZoneB" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LayoutZone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LayoutZone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LayoutZone",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LayoutZone",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LayoutZone",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Layout",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Layout",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
