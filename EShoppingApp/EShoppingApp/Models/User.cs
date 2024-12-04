using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Models
{
    public enum Roles
    {
        Admin,
        Supplier,
        Customer
    }
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty; 
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }
        public string Email { get; set; }        
        public Roles Role { get; set; }

        public Customer Customer { get; set; }
        public Admin Admin { get; set; }
        public Supplier Supplier { get; set; }

    }
}
