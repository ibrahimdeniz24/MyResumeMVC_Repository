using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyResume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Portfolios",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "Portfolios",
                newName: "Category");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectDate",
                table: "Portfolios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectDate",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Portfolios",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Portfolios",
                newName: "SubTitle");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
