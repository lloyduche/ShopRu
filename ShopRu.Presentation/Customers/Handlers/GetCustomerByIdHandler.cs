using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Application.Customers.Queries;
using ShopRu.Model;
using ShopRu.Persistence.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Application.Customers.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, ResponseDto<CustomerDto>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public GetCustomerByIdHandler(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }
        public async Task<ResponseDto<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = _shopRuContext.Customers.FirstOrDefault(x => x.Id == request.Id);
            if(customer == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    Message = $"Customer with {request.Id} does not exist",
                    Data = null,
                    Succeeded = false
                };

            }

            var conv = new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                IsAffliate = customer.IsAffliate,
                IsEmployee = customer.IsEmployee,
                DateCreated = customer.DateCreated

            };

            return new ResponseDto<CustomerDto>
            {
                Message = $"Customer with {request.Id}",
                Data = conv,
                Succeeded = true
            };
           

           
        }
    }
}
