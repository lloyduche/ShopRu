using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Customers.Models
{
    public class CustomerDto
    {
        [Key]
        public string Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        public bool IsAffliate { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
