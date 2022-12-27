using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class UpdatePaystubRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Paystubs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Paystubs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Paystubs_UserId",
                table: "Paystubs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paystubs_AspNetUsers_UserId",
                table: "Paystubs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paystubs_AspNetUsers_UserId",
                table: "Paystubs");

            migrationBuilder.DropIndex(
                name: "IX_Paystubs_UserId",
                table: "Paystubs");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Paystubs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Paystubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
