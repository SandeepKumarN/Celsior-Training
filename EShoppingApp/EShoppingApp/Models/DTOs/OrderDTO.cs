namespace EShoppingApp.Models.DTOs
{
    public class OrderDTO
    {
        //public int Id { get; set; }
        //public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        //public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
