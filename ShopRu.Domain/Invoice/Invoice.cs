using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Domain.Invoice
{
    public class Invoice
    {

        [Key]
        public string InvoiceId { get; set; } = Guid.NewGuid().ToString();
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubTotal { get; set; }
        public string CustomerId { get; set; }
        public List<InvoiceItem> Items { get; set; }
        
    }

    

}


