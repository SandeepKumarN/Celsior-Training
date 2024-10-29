namespace EFAPIProj.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderDetail()
        {
            Order Order = new Order();
            Product Product = new Product();
        }
    }
}
