using Core.Entities.Blog;
using Core.Entities.Code;
using Core.Entities.GitLab;
using Core.Entities.Resource;
using Core.Models;
using Environment = Core.Entities.Resource.Environment;

namespace EntityFramework;

public class ContextBase : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<CodeFolder> CodeFolders { get; set; } = null!;
    public DbSet<CodeSnippet> CodeSnippets { get; set; } = null!;
    public DbSet<CodeLibrary> CodeLibraries { get; set; } = null!;
    public DbSet<ConfigOption> ConfigOptions { get; set; } = null!;
    public DbSet<DocFolder> DocFolders { get; set; } = null!;
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;
    public DbSet<Resource> Resources { get; set; } = null!;
    public DbSet<ResourceAttribute> ResourceAttributes { get; set; } = null!;
    public DbSet<ResourceAttributeDefine> ResourceAttributeDefines { get; set; } = null!;
    public DbSet<ResourceGroup> ResourceGroups { get; set; } = null!;
    public DbSet<ResourceTags> ResourceTags { get; set; } = null!;
    public DbSet<ResourceTypeDefinition> ResourceTypeDefinitions { get; set; } = null!;
    public DbSet<Environment> Environments { get; set; } = null!;
    public DbSet<ResourceView> ResourceViews { get; set; } = null!;

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<BlogCatalog> BlogCatalogs { get; set; } = null!;
    public DbSet<BlogTag> BlogTags { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<GitLabUser> GitLabUsers { get; set; }
    public DbSet<GitLabProject> GitLabProjects { get; set; }
    public DbSet<GitLabEvent> GitLabEvents { get; set; }


    public ContextBase(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // 默认配置
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<EntityBase>().UseTpcMappingStrategy();

        _ = builder.Entity<ResourceView>()
            .ToView("ResrouceView")
            .HasNoKey();

        _ = builder.Entity<Blog>(e =>
        {
            _ = e.HasIndex(e => e.Title).IsUnique();
        });
        _ = builder.Entity<BlogCatalog>(e =>
        {
            _ = e.HasIndex(e => e.Name);
            _ = e.HasIndex(e => e.Level);
        });
        _ = builder.Entity<BlogTag>(e =>
        {
            _ = e.HasIndex(e => e.Name);
        });
        _ = builder.Entity<Resource>(e =>
        {
            _ = e.HasIndex(a => a.Name);
        });

        _ = builder.Entity<ResourceGroup>(e =>
        {
            _ = e.HasIndex(a => a.Name);
        });
        _ = builder.Entity<ResourceTags>(e =>
        {
            _ = e.HasIndex(a => a.Name);
        });
        _ = builder.Entity<ResourceTypeDefinition>(e =>
        {
            _ = e.HasIndex(a => a.Name);
        });
        _ = builder.Entity<Environment>(e =>
        {
            _ = e.HasIndex(a => a.Name);
        });

        _ = builder.Entity<User>(e =>
        {
            _ = e.HasIndex(a => a.Email);
            _ = e.HasIndex(a => a.PhoneNumber);
            _ = e.HasIndex(a => a.UserName);
            _ = e.HasIndex(a => a.IsDeleted);
            _ = e.HasIndex(a => a.CreatedTime);

        });
        _ = builder.Entity<Role>(e =>
        {
            _ = e.HasIndex(m => m.Name);
        });

        base.OnModelCreating(builder);
    }
}
