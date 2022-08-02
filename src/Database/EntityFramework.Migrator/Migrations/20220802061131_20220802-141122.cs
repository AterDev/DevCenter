using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrator.Migrations
{
    public partial class _20220802141122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "CodeLibraries");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CodeLibraries",
                type: "integer",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CodeLibraries");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CodeLibraries",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
