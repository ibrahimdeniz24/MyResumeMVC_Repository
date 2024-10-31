using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyResume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20241031_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Educations",
                type: "nvarchar(1300)",
                maxLength: 1300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Educations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1300)",
                oldMaxLength: 1300,
                oldNullable: true);
        }
    }
}
