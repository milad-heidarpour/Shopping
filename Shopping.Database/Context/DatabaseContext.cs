using Microsoft.EntityFrameworkCore;
using Shopping.Database.Model;

namespace Shopping.Database.Context;

public class DatabaseContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(@"Data source=.;
                            Initial Catalog=ShoppingDB;
                            Integrated Security=SSPI");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductClassification> ProductClassifications { get; set; }
    public DbSet<Commodity> Commodities { get; set; }
    public DbSet<CommodityAlbum> CommoditiesAlbum { get; set; }
    public DbSet<FeatureGroup> FeatureGroups { get; set; }
    public DbSet<FeatureSection> FeatureSections { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<CommodityFeature> CommodityFeatures { get; set; }

}
