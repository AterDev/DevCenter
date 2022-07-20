using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrator.Migrations;

public partial class _20220701183117 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_ResourceAttributeDefines_ResourceTypeDefinitions_ResourceTy~",
            table: "ResourceAttributeDefines");

        migrationBuilder.DropIndex(
            name: "IX_ResourceAttributeDefines_ResourceTypeDefinitionId",
            table: "ResourceAttributeDefines");

        migrationBuilder.DropColumn(
            name: "ResourceTypeDefinitionId",
            table: "ResourceAttributeDefines");

        migrationBuilder.CreateTable(
            name: "ResourceAttributeDefineResourceTypeDefinition",
            columns: table => new
            {
                AttributeDefinesId = table.Column<Guid>(type: "uuid", nullable: false),
                TypeDefinitionsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ResourceAttributeDefineResourceTypeDefinition", x => new { x.AttributeDefinesId, x.TypeDefinitionsId });
                table.ForeignKey(
                    name: "FK_ResourceAttributeDefineResourceTypeDefinition_ResourceAttri~",
                    column: x => x.AttributeDefinesId,
                    principalTable: "ResourceAttributeDefines",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ResourceAttributeDefineResourceTypeDefinition_ResourceTypeD~",
                    column: x => x.TypeDefinitionsId,
                    principalTable: "ResourceTypeDefinitions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ResourceAttributeDefineResourceTypeDefinition_TypeDefinitio~",
            table: "ResourceAttributeDefineResourceTypeDefinition",
            column: "TypeDefinitionsId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ResourceAttributeDefineResourceTypeDefinition");

        migrationBuilder.AddColumn<Guid>(
            name: "ResourceTypeDefinitionId",
            table: "ResourceAttributeDefines",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_ResourceAttributeDefines_ResourceTypeDefinitionId",
            table: "ResourceAttributeDefines",
            column: "ResourceTypeDefinitionId");

        migrationBuilder.AddForeignKey(
            name: "FK_ResourceAttributeDefines_ResourceTypeDefinitions_ResourceTy~",
            table: "ResourceAttributeDefines",
            column: "ResourceTypeDefinitionId",
            principalTable: "ResourceTypeDefinitions",
            principalColumn: "Id");
    }
}
