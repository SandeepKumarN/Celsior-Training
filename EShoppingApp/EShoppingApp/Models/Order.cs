using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
       // public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        //public User User { get; set; }
        public Customer Customer { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
