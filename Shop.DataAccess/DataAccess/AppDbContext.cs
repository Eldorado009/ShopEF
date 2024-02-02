using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace EFProjectApp.DataAccess;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=ShopDb;Trusted_Connection=true;encrypt=false;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Wallet> Wallets { get; set; } = null!;

   
}