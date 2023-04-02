using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using storeManagerDotNet.Models;

namespace storeManagerDotNet.Data;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<SaleProduct> SalesProducts { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public StoreContext (DbContextOptions<StoreContext> options) : base (options)
    {

    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Product>()
            .HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        mb.Entity<Product>()
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        mb.Entity<Sale>()
            .HasKey(x => x.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        mb.Entity<SaleProduct>().HasKey(x => new { x.ProductId, x.SaleId });
    }
}
