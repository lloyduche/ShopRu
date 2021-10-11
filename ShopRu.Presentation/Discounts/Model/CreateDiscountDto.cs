using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Discounts.Model
{
    public class CreateDiscountDto
    {
       
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
