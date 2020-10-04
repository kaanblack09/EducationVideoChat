using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEducation.Migrations
{
    public partial class ChangeDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "IdentityUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "IdentityUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
