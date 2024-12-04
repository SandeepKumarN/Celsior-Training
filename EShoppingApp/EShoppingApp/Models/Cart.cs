namespace EShoppingApp.Models
{
    public class Cart
    {
        public int Id { get; set; }

        //public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public Customer Customer { get; set; }
        //public User User { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
