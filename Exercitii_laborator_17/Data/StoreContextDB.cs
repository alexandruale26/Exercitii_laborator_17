using Exercitii_laborator_17.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercitii_laborator_17.Data
{
    public class StoreContextDB : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
        public DbSet<Label> Labels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-42S4FFT\\SQLEXPRESS;Initial Catalog=ShopMngmntDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
