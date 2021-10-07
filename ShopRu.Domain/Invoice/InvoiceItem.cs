namespace ShopRu.Domain.Invoice
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public long Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
