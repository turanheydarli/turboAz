using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PgSql")
                                     ?? throw new NullReferenceException(
                                         "Assign connection string in app settings.json"))
                .EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(b =>
        {
            b.ToTable("Brands");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");

            b.HasMany(p => p.Models)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);
        });

        modelBuilder.Entity<Model>(b =>
        {
            b.ToTable("Models");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
            b.Property(p => p.BrandId).HasColumnName("BrandId");

            b.HasOne(p => p.Brand)
                .WithMany(p => p.Models)
                .HasForeignKey(p => p.BrandId);
        });

        modelBuilder.Entity<Category>(b =>
        {
            b.ToTable("Categories");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.Property(p => p.Description).HasColumnName("Description");
            b.Property(p => p.Keywords).HasColumnName("Keywords");
            b.Property(p => p.Slug).HasColumnName("Slug");
            b.Property(p => p.Title).HasColumnName("Title");
            b.Property(p => p.Visibility).HasColumnName("Visibility");
            b.Property(p => p.CategoryOrder).HasColumnName("CategoryOrder");
            b.Property(p => p.FeaturedOrder).HasColumnName("FeaturedOrder");
            b.Property(p => p.HomepageOrder).HasColumnName("HomepageOrder");
            b.Property(p => p.IsFeatured).HasColumnName("IsFeatured");
            b.Property(p => p.ParentId).HasColumnName("ParentId");
            b.Property(p => p.ShowImageOnNavigation).HasColumnName("ShowImageOnNavigation");
            b.Property(p => p.ShowProductsOnIndex).HasColumnName("ShowProductsOnIndex");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.Updated).HasColumnName("Updated");
        });

        Category[] categoryEntitySeeds =
        {
            new(1, "test", null,
                "Test Category Name", "Test", 
                "Test Description", "test,keyword",
                1, 1, true, true, 1,
                true, true)
        };
        modelBuilder.Entity<Category>().HasData(categoryEntitySeeds);
        
        Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Audi") };
        modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

        Model[] modelEntitySeed = { new(1, "M5", 1, ""), new(2, "I8", 1, "") };
        modelBuilder.Entity<Model>().HasData(modelEntitySeed);
    }
}