using Core.Entities.Blog;
using Core.Entities.Code;
using Core.Entities.Resource;
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
        builder.UseHiLo();
        builder.Entity<ResourceView>()
            .ToView("ResrouceView")
            .HasNoKey();

        builder.Entity<Blog>(e =>
        {
            e.HasIndex(e => e.Title).IsUnique();
        });
        builder.Entity<BlogCatalog>(e =>
        {
            e.HasIndex(e => e.Name);
            e.HasIndex(e => e.Level);
        });
        builder.Entity<BlogTag>(e =>
        {
            e.HasIndex(e => e.Name);
        });
        builder.Entity<Resource>(e =>
        {
            e.HasIndex(a => a.Name);
        });

        builder.Entity<ResourceGroup>(e =>
        {
            e.HasIndex(a => a.Name);
        });
        builder.Entity<ResourceTags>(e =>
        {
            e.HasIndex(a => a.Name);
        });
        builder.Entity<ResourceTypeDefinition>(e =>
        {
            e.HasIndex(a => a.Name);
        });
        builder.Entity<Environment>(e =>
        {
            e.HasIndex(a => a.Name);
        });

        builder.Entity<User>(e =>
        {
            e.HasIndex(a => a.Email);
            e.HasIndex(a => a.PhoneNumber);
            e.HasIndex(a => a.UserName);
            e.HasIndex(a => a.IsDeleted);
            e.HasIndex(a => a.CreatedTime);

        });
        builder.Entity<Role>(e =>
        {
            e.HasIndex(m => m.Name);
        });

        base.OnModelCreating(builder);
    }
}
