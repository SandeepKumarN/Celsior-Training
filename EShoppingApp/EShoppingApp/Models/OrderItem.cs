using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } 
        public int OrderId { get; set; } 
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public OrderItem() 
        {
            Order = new Order();
            Product = new Product();
        }
    }
}
