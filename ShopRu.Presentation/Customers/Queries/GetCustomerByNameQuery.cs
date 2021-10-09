using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Customers.Queries
{
    public record GetCustomerByNameQuery: IRequest<ResponseDto<CustomerDto>>
    {
        public string Name { get; set; }
    }
}
