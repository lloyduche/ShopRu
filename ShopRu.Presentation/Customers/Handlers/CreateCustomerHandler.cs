using MediatR;
using ShopRu.Application.Customers.Commands;
using ShopRu.Application.Customers.Models;
using ShopRu.Domain.Customer;
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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ResponseDto<string>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public CreateCustomerHandler(IShopRuDbContext shopRuContext)
        {

            _shopRuContext = shopRuContext;
        }

        public async Task<ResponseDto<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
         {
            var customer = _shopRuContext.Customers.FirstOrDefault(x => x.Email == request.CreateCustomerDto.Email);
            if(customer != null)
            {
                return new ResponseDto<string>
                {
                    Message = $"Customer with {request.CreateCustomerDto.Email} already exist",
                    Data = null,
                    Succeeded = false
                };

            }

            var conv = new Customer
            {
                FirstName = request.CreateCustomerDto.FirstName,
                LastName = request.CreateCustomerDto.LastName,
                Email = request.CreateCustomerDto.Email,
                IsAffliate = request.CreateCustomerDto.IsAffliate,
                IsEmployee = request.CreateCustomerDto.IsEmployee

            };

            await _shopRuContext.Customers.AddAsync(conv);
            await _shopRuContext.SaveChangesAsync();
            return new ResponseDto<string>
            {
                Message = "Client created Successfully",
                Succeeded = true,
                Data = "Customer Id : "+ conv.Id
            };
        }
    }
}
