using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp
{
    internal class ShoppingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = 5CD112KHSJ\\SANDEEPKUMAR; Integrated Security = true; Initial Catalog = NewDatabase; TrustServerCertificate = true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }
    }
}
//optionsBuilder.UseSqlServer("Server=5CD112KHSJ\\SANDEEPKUMAR;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=true");