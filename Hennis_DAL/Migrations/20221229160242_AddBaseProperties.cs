using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class AddBaseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Paystubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Paystubs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Paystubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Paystubs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Page",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Page",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Page",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Page",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LayoutZone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "LayoutZone",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "LayoutZone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "LayoutZone",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Layout",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Layout",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HtmlContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HtmlContent",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HtmlContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HtmlContent",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BinaryFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "BinaryFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BinaryFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "BinaryFile",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Paystubs");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Paystubs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Paystubs");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Paystubs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LayoutZone");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "LayoutZone");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "LayoutZone");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "LayoutZone");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HtmlContent");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HtmlContent");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HtmlContent");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HtmlContent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BinaryFile");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "BinaryFile");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BinaryFile");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "BinaryFile");
        }
    }
}
