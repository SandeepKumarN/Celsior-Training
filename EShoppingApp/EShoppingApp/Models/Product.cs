namespace EShoppingApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string BasicImage { get; set; } = string.Empty ;
        public string Description { get; set; } = string.Empty ;

        
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public Product() 
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
