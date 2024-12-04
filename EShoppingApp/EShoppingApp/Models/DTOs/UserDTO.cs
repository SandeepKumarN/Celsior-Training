namespace EShoppingApp.Models.DTOs
{
    public class UserDTO
    {
        public string id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
