using ShopRu.Domain;
using ShopRu.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Invoices.Model
{
    public class CreateInvoiceDto
    {
        public string CustomerId { get; set; }

        public List<InvoiceItemDto> Items { get; set; }

        public decimal TotalPriceOfItems()
        {
            decimal Total = 0;
            foreach (var item in Items)
            {
                Total += item.PriceOfEachItem();
            }
            return Total;
        }

    }

    public class InvoiceItemDto
    {
        [Required]
        public long Quantity { get; set; }

        [Required]
        public string ItemId { get; set; }
        public ItemDto item { get; set; }

        public decimal PriceOfEachItem()
        {
            return Quantity * item.Amount;
        }
    }

    public class ItemDto
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
