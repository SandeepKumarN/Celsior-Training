﻿using System.Collections.Generic;

namespace EFAPIProj.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Cart Cart { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
            Cart = new Cart();
        }
    }
}
