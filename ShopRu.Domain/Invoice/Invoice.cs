using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Domain.Invoice
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public string RecipientId { get; set; }
        public List<InvoiceItem> Items { get; set; }
        
    }

    

}


