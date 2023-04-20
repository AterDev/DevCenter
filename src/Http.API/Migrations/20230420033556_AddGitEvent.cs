using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Http.API.Migrations
{
    /// <inheritdoc />
    public partial class AddGitEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitLabCommits");

            migrationBuilder.CreateTable(
                name: "GitLabEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    SourceId = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    BranchName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CommitTitle = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    CommitCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitLabEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitLabEvents_GitLabProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "GitLabProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GitLabEvents_GitLabUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "GitLabUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GitLabUsers_CreatedTime",
                table: "GitLabUsers",
                column: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_CommitTitle",
                table: "GitLabEvents",
                column: "CommitTitle");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_Day",
                table: "GitLabEvents",
                column: "Day");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_Month",
                table: "GitLabEvents",
                column: "Month");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_ProjectId",
                table: "GitLabEvents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_SourceId",
                table: "GitLabEvents",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_UserId",
                table: "GitLabEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GitLabEvents_Year",
                table: "GitLabEvents",
                column: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitLabEvents");

            migrationBuilder.DropIndex(
                name: "IX_GitLabUsers_CreatedTime",
                table: "GitLabUsers");

            migrationBuilder.CreateTable(
                name: "GitLabCommits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddCount = table.Column<int>(type: "integer", nullable: false),
                    DeleteCount = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SourceId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
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
        }
    }
}
