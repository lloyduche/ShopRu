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
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CustomerId { get; set; }
        public ICollection<InvoiceItem> Items { get; set; }
        
    }

    

}


