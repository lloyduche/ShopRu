using ShopRu.Application.Invoices.Model;
using ShopRu.Application.Invoices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Logic
{
    public interface IDiscountLogic
    {
        Task<InvoiceDto> CalculateDiscount(GenerateInvoiceQuery model, string type);
    }
}
