using System.ComponentModel.DataAnnotations;

namespace ShopRu.Domain.Invoice
{
    public class InvoiceItem
    {

        [Key]
        public int InvoiceItemId { get; set; }
        public long Quantity { get; set; }
        public string ItemId { get; set; }
        public Item Item { get; set; }

       
    }
}
