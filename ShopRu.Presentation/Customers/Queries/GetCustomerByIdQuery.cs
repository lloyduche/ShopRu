using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Model;

namespace ShopRu.Application.Customers.Queries
{
    public record GetCustomerByIdQuery: IRequest<ResponseDto<CustomerDto>>
    {
        public string Id { get; set; }
    }
    
}
