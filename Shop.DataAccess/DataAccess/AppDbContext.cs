using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using System.Net.Mail;

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
    public DbSet<Basket> Baskets { get; set; } = null!;
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    


   
}