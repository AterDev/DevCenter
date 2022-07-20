using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrator.Migrations;

public partial class _20220711184700 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "LayoutType",
            table: "ResourceGroups",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Navigation",
            table: "ResourceGroups",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Sort",
            table: "ResourceGroups",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "LayoutType",
            table: "ResourceGroups");

        migrationBuilder.DropColumn(
            name: "Navigation",
            table: "ResourceGroups");

        migrationBuilder.DropColumn(
            name: "Sort",
            table: "ResourceGroups");
    }
}
