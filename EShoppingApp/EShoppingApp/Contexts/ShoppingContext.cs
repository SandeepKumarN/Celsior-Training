using EShoppingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EShoppingApp.Contexts
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<OrderItem> items { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
           base.OnModelCreating(modelBuilder);

            // Cart -> User (One-to-Many relationship)
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer) // A Cart has one User
                .WithMany(u => u.Carts) // A User can have many Carts
                .HasForeignKey(c => c.CustomerId) // Foreign key: UserId
                .HasConstraintName("FK_Cart_User"); // Custom foreign key constraint name

            // CartItem -> Cart (Many-to-One relationship)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart) // A CartItem belongs to one Cart
                .WithMany(c => c.CartItems) // A Cart has many CartItems
                .HasForeignKey(ci => ci.CartId) // Foreign key: CartId
                .HasConstraintName("FK_CartItem_Cart"); // Custom foreign key constraint name

            // CartItem -> Product (Many-to-One relationship)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product) // A CartItem belongs to one Product
                .WithMany(p => p.CartItems) // A Product can have many CartItems
                .HasForeignKey(ci => ci.ProductId) // Foreign key: ProductId
                .HasConstraintName("FK_CartItem_Product"); // Custom foreign key constraint name

            // Order -> User (Many-to-One relationship)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer) // An Order belongs to one User
                .WithMany(u => u.Orders) // A User can have many Orders
                .HasForeignKey(o => o.CustomerId); // Custom foreign key constraint name

            // OrderItem -> Order (Many-to-One relationship)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order) // An OrderItem belongs to one Order
                .WithMany(o => o.OrderItems) // An Order can have many OrderItems
                .HasForeignKey(oi => oi.OrderId) // Foreign key: OrderId
                .HasConstraintName("FK_OrderItem_Order"); // Custom foreign key constraint name

            // OrderItem -> Product (Many-to-One relationship)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product) // An OrderItem belongs to one Product
                .WithMany(p => p.OrderItems) // A Product can have many OrderItems
                .HasForeignKey(oi => oi.ProductId) // Foreign key: ProductId
                .HasConstraintName("FK_OrderItem_Product"); // Custom foreign key constraint name

            // Product -> OrderItem (One-to-Many relationship)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems) // A Product can have many OrderItems
                .WithOne(oi => oi.Product) // An OrderItem belongs to one Product
                .HasForeignKey(oi => oi.ProductId) // Foreign key: ProductId
                .HasConstraintName("FK_Product_OrderItem"); // Custom foreign key constraint name

            // Product -> CartItem (One-to-Many relationship)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems) // A Product can have many CartItems
                .WithOne(ci => ci.Product) // A CartItem belongs to one Product
                .HasForeignKey(ci => ci.ProductId) // Foreign key: ProductId
                .HasConstraintName("FK_Product_CartItem");

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User) // A Product can have many CartItems
                .WithOne(u => u.Customer) // A CartItem belongs to one Product
                .HasForeignKey<Customer>(c => c.UserId) // Foreign key: ProductId
                .HasConstraintName("FK_Customer_User");

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User) // A Product can have many CartItems
                .WithOne(u => u.Admin) // A CartItem belongs to one Product
                .HasForeignKey<Admin>(c => c.UserId) // Foreign key: ProductId
                .HasConstraintName("FK_Admin_User");

            modelBuilder.Entity<Supplier>()
                .HasOne(a => a.User) // A Product can have many CartItems
                .WithOne(u => u.Supplier) // A CartItem belongs to one Product
                .HasForeignKey<Supplier>(c => c.UserId) // Foreign key: ProductId
                .HasConstraintName("FK_Supplier_User");
        }
    }
}