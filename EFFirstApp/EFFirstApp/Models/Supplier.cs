﻿using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
        public class Supplier
        {
            public int SupplierId { get; set; }
            public string SupplierName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;

            public IEnumerable<SupplierProduct> SupplierProducts { get; set; }

        }
    
}




/* Microsoft.EntityFrameworkCore.SqlServer - 6.0.35
Microsoft.EntityFrameworkCore.Tools 6.0.35




----------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class Product
    {
        public int Id { get; set; }//by default primary key, Also Idenetity with starting number 1 and increment 1
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
------------------------------------------------------------
using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Contexts
{
    public class ShoppingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=G3SLAPTOP\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEFCode15Oct24;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
    }
}
-------------------------------------------------------
Tools->NuGet Package Manager -> Package Manager Console


Add-Migration init
update-database
---------------------------------------------------------
using EFFirstApp.Contexts;
using EFFirstApp.Models;

namespace EFFirstApp
{
    internal class Program
    {
        ShoppingContext context = new ShoppingContext();
        Product CreateAndPopulateProduct()
        {
            Product product = new Product();
            Console.WriteLine("Please enter the Product Name");
            product.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter the Product Price");
            product.Price = float.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please enter the Product Quantity");
            product.Quantity = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please enter the Product Image");
            product.Image = Console.ReadLine() ?? "";
            return product;
        }
        void InsertProduct()
        {
            Product product = CreateAndPopulateProduct();
            try
            {
                context.Products.Add(product);//This will add to the local collection
                context.SaveChanges();//This will execute all the DML commands
                Console.WriteLine("Product added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Product not added");
            }
        }
        void GetProducts()
        {
            var products = context.Products.ToList();
            products = products.OrderByDescending(p => p.Price).ToList();
            PrintProducts(products);
        }
        void PrintProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id:{product.Id}\nName:{product.Name}\nPrice:{product.Price}\nQuantity:{product.Quantity}\nImage:{product.Image}");
                Console.WriteLine("-------------------------");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.InsertProduct();
            program.GetProducts();
        }
    }
}
-------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class Product
    {
        public int Id { get; set; }//by default primary key, Also Idenetity with starting number 1 and increment 1
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
--------------------------------------------
Add - Migration changeproduct
update-database
-----------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class Product
    {
        public int Id { get; set; }//by default primary key, Also Idenetity with starting number 1 and increment 1
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }//Navigation property will be included in the database
        //public string Description { get; set; } = string.Empty;
    }
}
-------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; }//Navigation property will be included in the database
    }
}
----------------------------------------------
using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Contexts
{
    public class ShoppingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=G3SLAPTOP\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEFCode15Oct24;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public IEnumerable<SupplierProduct> SupplierProducts { get; set; }

    }
}
--------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Models
{
    public class SupplierProduct
    {
        [Key]//annotation for primary key
        public int PurchaseNumber { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
----------------------------------------------
using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Contexts
{
    public class ShoppingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=G3SLAPTOP\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEFCode15Oct24;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }
    }
}
*/



