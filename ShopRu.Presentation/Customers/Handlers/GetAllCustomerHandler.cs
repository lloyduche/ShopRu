using MediatR;
using ShopRu.Application.Customers.Models;
using ShopRu.Application.Customers.Queries;
using ShopRu.Model;
using ShopRu.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Application.Customers.Handlers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, ResponseDto<List<CustomerDto>>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public GetAllCustomerHandler(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }

        public async Task<ResponseDto<List<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CustomerDto>();
            var customers = _shopRuContext.Customers.ToList();
            foreach (var item in customers)
            {
                var myCustomer = new CustomerDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    IsAffliate = item.IsAffliate,
                    IsEmployee = item.IsEmployee,
                    DateCreated = item.DateCreated

                };
                result.Add(myCustomer);
            }

            return new ResponseDto<List<CustomerDto>> {

                Message = $"List of All registered Customers",
                Succeeded = true,
                Data = result,
                Code = "201"

             };
        }
    }
}
