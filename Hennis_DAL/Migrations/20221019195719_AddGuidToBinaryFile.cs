using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hennis_DAL.Migrations
{
    public partial class AddGuidToBinaryFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "BinaryFile",
                type: "uniqueidentifier",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Guid",
               table: "BinaryFile");
        }
    }
}
