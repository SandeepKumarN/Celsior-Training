namespace EShoppingApp.Models.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; }
        public string userId { get; set; } 
    }
}
