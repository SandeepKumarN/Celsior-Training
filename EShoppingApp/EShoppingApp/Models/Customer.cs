using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
        public Cart Cart { get; set; }

    }
}
