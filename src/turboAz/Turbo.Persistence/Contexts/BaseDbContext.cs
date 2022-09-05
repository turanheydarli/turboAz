using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Turbo.Domain.Entities.Catalog;
using Turbo.Domain.Entities.Media;

namespace Turbo.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Gear> Gears { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<ConversationMessage> ConversationMessages { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<GeneralSetting> GeneralSettings { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<ProductProperty> ProductProperties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

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
        });

        Brand[] brandEntitySeeds = { new Brand { Id = 1, Name = "BMW" }, new Brand { Id = 2, Name = "Audi" } };

        modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

        modelBuilder.Entity<Product>()
            .HasOne(a => a.ProductDetail)
            .WithOne(a => a.Product)
            .HasForeignKey<ProductDetail>(c => c.ProductId);

        modelBuilder.Entity<ProductDetail>()
            .HasMany(p => p.Pictures)
            .WithOne(p => p.ProductDetail)
            .HasForeignKey(p => p.ProductDetailId);
    }
}