using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Discounts.Model
{
    public class DiscountDto
    {
        public string Id { get; set; }

        public decimal Rate { get; set; }
        public string Type { get; set; }
    }
}
