using System;
using System.ComponentModel.DataAnnotations;

namespace ShopRu.Domain.Customer
{
    public class Customer
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string  FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string  LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string  Email { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
