using MediatR;
using ShopRu.Application.Invoices.Model;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Invoices.Queries
{
    public record GenerateInvoiceQuery: IRequest<ResponseDto<InvoiceDto>>
    {
        public CreateInvoiceDto CreateInvoiceDto { get; set; }
    }
}
