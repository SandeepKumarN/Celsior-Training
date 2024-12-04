﻿namespace EShoppingApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}