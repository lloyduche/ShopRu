using MediatR;
using ShopRu.Application.Invoices.Model;
using ShopRu.Application.Invoices.Queries;
using ShopRu.Application.Logic;
using ShopRu.Model;
using ShopRu.Persistence.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Application.Invoices.Handlers
{
    public class GenerateInvoiceHandler : IRequestHandler<GenerateInvoiceQuery, ResponseDto<InvoiceDto>>
    {
        private readonly IShopRuDbContext _shopRuContext;
        private readonly IDiscountLogic _discountLogic;

        public GenerateInvoiceHandler(IShopRuDbContext shopRuContext, IDiscountLogic discountLogic)
        {
            _shopRuContext = shopRuContext;
            _discountLogic = discountLogic;

        }
        public async Task<ResponseDto<InvoiceDto>> Handle(GenerateInvoiceQuery request, CancellationToken cancellationToken)
        {
            var result = new InvoiceDto();
            var GetCustomer =  _shopRuContext.Customers.FirstOrDefault(x => x.Id == request.CreateInvoiceDto.CustomerId);

            if(GetCustomer == null)
            {
                return new ResponseDto<InvoiceDto>
                {
                    Message = $"Customer with id: {request.CreateInvoiceDto.CustomerId} is not a registered customer",
                    Succeeded = false,
                    Data = null
                };
            }

            if(GetCustomer.IsAffliate == true)
            {
                var type = "Affiliate";
                //pass the bill to generate the total discount
                result = await _discountLogic.CalculateDiscount(request, type);

            }


            
            if(GetCustomer.IsEmployee == true)
            {
                var type = "Employee";
                //pass the bill to generate the total discount
                 result = await _discountLogic.CalculateDiscount(request, type);
            }


            if (GetCustomer.IsAffliate == false && GetCustomer.IsEmployee == false)
            {
                var year = GetCustomer.DateCreated.AddYears(2);
                if ( DateTime.Now >= year )
                {
                    var type = "OverTwoYears";
                    //pass the bill to generate the total discount
                    result = await _discountLogic.CalculateDiscount(request, type);

                }
                else { 
               
                    return new ResponseDto<InvoiceDto>
                    {
                        Message = $"Customer with id: {request.CreateInvoiceDto.CustomerId} is not Qualified",
                        Succeeded = false,
                        Data = null
                    };
                }
            }
           
            return new ResponseDto<InvoiceDto>
            {
                Message = $"Invoice Id {result.InvoiceId}",
                Succeeded = true,
                Data = result
            };
        }
    }
}
