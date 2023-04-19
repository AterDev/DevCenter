using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Http.API.Migrations
{
    /// <inheritdoc />
    public partial class AddGitLabUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ResourceAttributeDefines",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "GitLabProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitLabProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GitLabUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AvatarUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitLabUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GitLabCommits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AddCount = table.Column<int>(type: "integer", nullable: false),
                    DeleteCount = table.Column<int>(type: "integer", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitLabCommits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitLabCommits_GitLabProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "GitLabProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GitLabCommits_GitLabUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "GitLabUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GitLabCommits_Name",
                table: "GitLabCommits",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabCommits_ProjectId",
                table: "GitLabCommits",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabCommits_SourceId",
                table: "GitLabCommits",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabCommits_UserId",
                table: "GitLabCommits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabProjects_Name",
                table: "GitLabProjects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabProjects_SourceId",
                table: "GitLabProjects",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabUsers_Email",
                table: "GitLabUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GitLabUsers_Name",
                table: "GitLabUsers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabUsers_SourceId",
                table: "GitLabUsers",
                column: "SourceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitLabCommits");

            migrationBuilder.DropTable(
                name: "GitLabProjects");

            migrationBuilder.DropTable(
                name: "GitLabUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ResourceAttributeDefines",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
