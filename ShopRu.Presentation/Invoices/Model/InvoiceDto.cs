using ShopRu.Application.Customers.Models;
using ShopRu.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Invoices.Model
{
    public class InvoiceDto
    {

        public string InvoiceId { get; set; }
        public CustomerInfo Customer { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal SubTotal { get; set; }

        public List<InvoiceItemDto> ItemsPurchased { get; set; }

    }

    public class CustomerInfo
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
