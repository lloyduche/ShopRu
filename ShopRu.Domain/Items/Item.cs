using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Domain
{
    public class Item
    {
        [Key]
        public string  ItemId { get; set; }

        public string Type { get; set; }

        public string ItemName { get; set; }

        public decimal Amount { get; set; }


    }
}
