using System;
using System.ComponentModel.DataAnnotations;

namespace ShopRu.Domain.Discount
{
    public class Discount
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Rate { get; set; }
        public string  Type { get; set; }
    }
}
