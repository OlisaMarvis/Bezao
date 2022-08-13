using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Wallet Wallet { get; set; }
        public string Password { get; set; }    
    }
}
