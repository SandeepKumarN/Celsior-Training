namespace EShoppingApp.Models.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;         
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string BasicImage { get; set; } = string.Empty;     
        public string Description { get; set; } = string.Empty;
    }
}
