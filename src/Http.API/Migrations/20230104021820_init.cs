using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Http.API.Migrations;

/// <inheritdoc />
public partial class init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateSequence(
            name: "EntityFrameworkHiLoSequence",
            incrementBy: 10);

        _ = migrationBuilder.CreateTable(
            name: "BlogCatalogs",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                Sort = table.Column<short>(type: "smallint", nullable: false),
                Level = table.Column<short>(type: "smallint", nullable: false),
                ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_BlogCatalogs", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_BlogCatalogs_BlogCatalogs_ParentId",
                    column: x => x.ParentId,
                    principalTable: "BlogCatalogs",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "BlogTags",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                Icon = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_BlogTags", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "CodeFolders",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_CodeFolders", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_CodeFolders_CodeFolders_ParentId",
                    column: x => x.ParentId,
                    principalTable: "CodeFolders",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "ConfigOptions",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                Type = table.Column<int>(type: "integer", nullable: false),
                DisplayValue = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                MinValue = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                MaxValue = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ConfigOptions", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "DocFolders",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_DocFolders", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_DocFolders_DocFolders_ParentId",
                    column: x => x.ParentId,
                    principalTable: "DocFolders",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "Environments",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Environments", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Permissions",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                PermissionPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Permissions", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Permissions_Permissions_ParentId",
                    column: x => x.ParentId,
                    principalTable: "Permissions",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceAttributeDefines",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                DisplayName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                Type = table.Column<int>(type: "integer", nullable: false),
                IsEnable = table.Column<bool>(type: "boolean", nullable: false),
                Required = table.Column<bool>(type: "boolean", nullable: false),
                Sort = table.Column<short>(type: "smallint", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceAttributeDefines", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceTags",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                Icon = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceTags", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceTypeDefinitions",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                Icon = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                Color = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceTypeDefinitions", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                IdentifyName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                Icon = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Roles", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                UserName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                RealName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                Position = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                PasswordHash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                PasswordSalt = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                LastLoginTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                RetryCount = table.Column<int>(type: "integer", nullable: false),
                Avatar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Users", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Documents",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Ext = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                FilePath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                FolderId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Documents", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Documents_DocFolders_FolderId",
                    column: x => x.FolderId,
                    principalTable: "DocFolders",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceGroups",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Descriptioin = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                Sort = table.Column<int>(type: "integer", nullable: false),
                LayoutType = table.Column<int>(type: "integer", nullable: false),
                Navigation = table.Column<int>(type: "integer", nullable: false),
                EnvironmentId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceGroups", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_ResourceGroups_Environments_EnvironmentId",
                    column: x => x.EnvironmentId,
                    principalTable: "Environments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceAttributeDefineResourceTypeDefinition",
            columns: table => new {
                AttributeDefinesId = table.Column<Guid>(type: "uuid", nullable: false),
                TypeDefinitionsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceAttributeDefineResourceTypeDefinition", x => new { x.AttributeDefinesId, x.TypeDefinitionsId });
                _ = table.ForeignKey(
                    name: "FK_ResourceAttributeDefineResourceTypeDefinition_ResourceAttri~",
                    column: x => x.AttributeDefinesId,
                    principalTable: "ResourceAttributeDefines",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_ResourceAttributeDefineResourceTypeDefinition_ResourceTypeD~",
                    column: x => x.TypeDefinitionsId,
                    principalTable: "ResourceTypeDefinitions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "PermissionRole",
            columns: table => new {
                PermissionsId = table.Column<Guid>(type: "uuid", nullable: false),
                RolesId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsId, x.RolesId });
                _ = table.ForeignKey(
                    name: "FK_PermissionRole_Permissions_PermissionsId",
                    column: x => x.PermissionsId,
                    principalTable: "Permissions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_PermissionRole_Roles_RolesId",
                    column: x => x.RolesId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "RolePermissions",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                PermissionTypeMyProperty = table.Column<int>(type: "integer", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_RolePermissions", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_RolePermissions_Permissions_PermissionId",
                    column: x => x.PermissionId,
                    principalTable: "Permissions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_RolePermissions_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Blogs",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Summary = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                AuthorName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                IsPrivate = table.Column<bool>(type: "boolean", nullable: true),
                Content = table.Column<string>(type: "character varying(12000)", maxLength: 12000, nullable: true),
                CatalogId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Blogs", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Blogs_BlogCatalogs_CatalogId",
                    column: x => x.CatalogId,
                    principalTable: "BlogCatalogs",
                    principalColumn: "Id");
                _ = table.ForeignKey(
                    name: "FK_Blogs_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "CodeLibraries",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Namespace = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                Type = table.Column<int>(type: "integer", nullable: false),
                IsValid = table.Column<bool>(type: "boolean", nullable: false),
                IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_CodeLibraries", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_CodeLibraries_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "RoleUser",
            columns: table => new {
                RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                UsersId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                _ = table.ForeignKey(
                    name: "FK_RoleUser_Roles_RolesId",
                    column: x => x.RolesId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_RoleUser_Users_UsersId",
                    column: x => x.UsersId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceGroupRole",
            columns: table => new {
                ResourceGroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                RolesId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceGroupRole", x => new { x.ResourceGroupsId, x.RolesId });
                _ = table.ForeignKey(
                    name: "FK_ResourceGroupRole_ResourceGroups_ResourceGroupsId",
                    column: x => x.ResourceGroupsId,
                    principalTable: "ResourceGroups",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_ResourceGroupRole_Roles_RolesId",
                    column: x => x.RolesId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Resources",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                ResourceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Resources", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Resources_ResourceGroups_GroupId",
                    column: x => x.GroupId,
                    principalTable: "ResourceGroups",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_Resources_ResourceTypeDefinitions_ResourceTypeId",
                    column: x => x.ResourceTypeId,
                    principalTable: "ResourceTypeDefinitions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "BlogBlogTag",
            columns: table => new {
                BlogTagsId = table.Column<Guid>(type: "uuid", nullable: false),
                BlogsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_BlogBlogTag", x => new { x.BlogTagsId, x.BlogsId });
                _ = table.ForeignKey(
                    name: "FK_BlogBlogTag_BlogTags_BlogTagsId",
                    column: x => x.BlogTagsId,
                    principalTable: "BlogTags",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_BlogBlogTag_Blogs_BlogsId",
                    column: x => x.BlogsId,
                    principalTable: "Blogs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Comments", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Comments_Blogs_BlogId",
                    column: x => x.BlogId,
                    principalTable: "Blogs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_Comments_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "CodeSnippets",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                Content = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                LibraryId = table.Column<Guid>(type: "uuid", nullable: true),
                Language = table.Column<int>(type: "integer", nullable: false),
                CodeType = table.Column<int>(type: "integer", nullable: false),
                CodeFolderId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_CodeSnippets", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_CodeSnippets_CodeFolders_CodeFolderId",
                    column: x => x.CodeFolderId,
                    principalTable: "CodeFolders",
                    principalColumn: "Id");
                _ = table.ForeignKey(
                    name: "FK_CodeSnippets_CodeLibraries_LibraryId",
                    column: x => x.LibraryId,
                    principalTable: "CodeLibraries",
                    principalColumn: "Id");
                _ = table.ForeignKey(
                    name: "FK_CodeSnippets_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceAttributes",
            columns: table => new {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                DisplayName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                Type = table.Column<int>(type: "integer", nullable: false),
                IsEnable = table.Column<bool>(type: "boolean", nullable: false),
                Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                Sort = table.Column<short>(type: "smallint", nullable: false),
                ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceAttributes", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_ResourceAttributes_Resources_ResourceId",
                    column: x => x.ResourceId,
                    principalTable: "Resources",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "ResourceResourceTags",
            columns: table => new {
                ResourcesId = table.Column<Guid>(type: "uuid", nullable: false),
                TagsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_ResourceResourceTags", x => new { x.ResourcesId, x.TagsId });
                _ = table.ForeignKey(
                    name: "FK_ResourceResourceTags_ResourceTags_TagsId",
                    column: x => x.TagsId,
                    principalTable: "ResourceTags",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_ResourceResourceTags_Resources_ResourcesId",
                    column: x => x.ResourcesId,
                    principalTable: "Resources",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_BlogBlogTag_BlogsId",
            table: "BlogBlogTag",
            column: "BlogsId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_BlogCatalogs_Level",
            table: "BlogCatalogs",
            column: "Level");

        _ = migrationBuilder.CreateIndex(
            name: "IX_BlogCatalogs_Name",
            table: "BlogCatalogs",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_BlogCatalogs_ParentId",
            table: "BlogCatalogs",
            column: "ParentId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Blogs_CatalogId",
            table: "Blogs",
            column: "CatalogId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Blogs_Title",
            table: "Blogs",
            column: "Title",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_Blogs_UserId",
            table: "Blogs",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_BlogTags_Name",
            table: "BlogTags",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_CodeFolders_ParentId",
            table: "CodeFolders",
            column: "ParentId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_CodeLibraries_UserId",
            table: "CodeLibraries",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_CodeSnippets_CodeFolderId",
            table: "CodeSnippets",
            column: "CodeFolderId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_CodeSnippets_LibraryId",
            table: "CodeSnippets",
            column: "LibraryId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_CodeSnippets_UserId",
            table: "CodeSnippets",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Comments_BlogId",
            table: "Comments",
            column: "BlogId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Comments_UserId",
            table: "Comments",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_DocFolders_ParentId",
            table: "DocFolders",
            column: "ParentId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Documents_FolderId",
            table: "Documents",
            column: "FolderId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Environments_Name",
            table: "Environments",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_PermissionRole_RolesId",
            table: "PermissionRole",
            column: "RolesId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Permissions_ParentId",
            table: "Permissions",
            column: "ParentId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceAttributeDefineResourceTypeDefinition_TypeDefinitio~",
            table: "ResourceAttributeDefineResourceTypeDefinition",
            column: "TypeDefinitionsId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceAttributes_ResourceId",
            table: "ResourceAttributes",
            column: "ResourceId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceGroupRole_RolesId",
            table: "ResourceGroupRole",
            column: "RolesId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceGroups_EnvironmentId",
            table: "ResourceGroups",
            column: "EnvironmentId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceGroups_Name",
            table: "ResourceGroups",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceResourceTags_TagsId",
            table: "ResourceResourceTags",
            column: "TagsId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Resources_GroupId",
            table: "Resources",
            column: "GroupId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Resources_Name",
            table: "Resources",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Resources_ResourceTypeId",
            table: "Resources",
            column: "ResourceTypeId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceTags_Name",
            table: "ResourceTags",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_ResourceTypeDefinitions_Name",
            table: "ResourceTypeDefinitions",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RolePermissions_PermissionId",
            table: "RolePermissions",
            column: "PermissionId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RolePermissions_RoleId",
            table: "RolePermissions",
            column: "RoleId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Roles_Name",
            table: "Roles",
            column: "Name");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RoleUser_UsersId",
            table: "RoleUser",
            column: "UsersId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_CreatedTime",
            table: "Users",
            column: "CreatedTime");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_Email",
            table: "Users",
            column: "Email");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_IsDeleted",
            table: "Users",
            column: "IsDeleted");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_PhoneNumber",
            table: "Users",
            column: "PhoneNumber");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_UserName",
            table: "Users",
            column: "UserName");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "BlogBlogTag");

        _ = migrationBuilder.DropTable(
            name: "CodeSnippets");

        _ = migrationBuilder.DropTable(
            name: "Comments");

        _ = migrationBuilder.DropTable(
            name: "ConfigOptions");

        _ = migrationBuilder.DropTable(
            name: "Documents");

        _ = migrationBuilder.DropTable(
            name: "PermissionRole");

        _ = migrationBuilder.DropTable(
            name: "ResourceAttributeDefineResourceTypeDefinition");

        _ = migrationBuilder.DropTable(
            name: "ResourceAttributes");

        _ = migrationBuilder.DropTable(
            name: "ResourceGroupRole");

        _ = migrationBuilder.DropTable(
            name: "ResourceResourceTags");

        _ = migrationBuilder.DropTable(
            name: "RolePermissions");

        _ = migrationBuilder.DropTable(
            name: "RoleUser");

        _ = migrationBuilder.DropTable(
            name: "BlogTags");

        _ = migrationBuilder.DropTable(
            name: "CodeFolders");

        _ = migrationBuilder.DropTable(
            name: "CodeLibraries");

        _ = migrationBuilder.DropTable(
            name: "Blogs");

        _ = migrationBuilder.DropTable(
            name: "DocFolders");

        _ = migrationBuilder.DropTable(
            name: "ResourceAttributeDefines");

        _ = migrationBuilder.DropTable(
            name: "ResourceTags");

        _ = migrationBuilder.DropTable(
            name: "Resources");

        _ = migrationBuilder.DropTable(
            name: "Permissions");

        _ = migrationBuilder.DropTable(
            name: "Roles");

        _ = migrationBuilder.DropTable(
            name: "BlogCatalogs");

        _ = migrationBuilder.DropTable(
            name: "Users");

        _ = migrationBuilder.DropTable(
            name: "ResourceGroups");

        _ = migrationBuilder.DropTable(
            name: "ResourceTypeDefinitions");

        _ = migrationBuilder.DropTable(
            name: "Environments");

        _ = migrationBuilder.DropSequence(
            name: "EntityFrameworkHiLoSequence");
    }
}
