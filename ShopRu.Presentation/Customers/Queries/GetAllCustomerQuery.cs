using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Model;
using System.Collections.Generic;

namespace ShopRu.Application.Customers.Queries
{
    public record GetAllCustomerQuery : IRequest<ResponseDto<List<CustomerDto>>>;
    
}
