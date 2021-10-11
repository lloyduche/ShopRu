using System;
using System.ComponentModel.DataAnnotations;

namespace ShopRu.Domain.Invoice
{
    public class InvoiceItem
    {

        [Key]
        public string InvoiceItemId { get; set; } = Guid.NewGuid().ToString();
        public long Quantity { get; set; }
        public string ItemId { get; set; }
        
    }
}

