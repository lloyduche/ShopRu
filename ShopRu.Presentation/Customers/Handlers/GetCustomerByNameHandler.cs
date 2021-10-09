using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Application.Customers.Queries;
using ShopRu.Model;
using ShopRu.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Application.Customers.Handlers
{
    public class GetCustomerByNameHandler : IRequestHandler<GetCustomerByNameQuery, ResponseDto<CustomerDto>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public GetCustomerByNameHandler(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }
        public async Task<ResponseDto<CustomerDto>> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
        {
            var customer = _shopRuContext.Customers.FirstOrDefault(x => x.FirstName == request.Name || x.LastName == request.Name);
            if (customer == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    Message = $"Customer with {request.Name} not found",
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
                Message = $"Customer with {request.Name}",
                Data = conv,
                Succeeded = true
            };
        }
    }
}
