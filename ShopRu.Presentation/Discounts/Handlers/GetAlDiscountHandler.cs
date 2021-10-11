using MediatR;
using ShopRu.Application.Discounts.Model;
using ShopRu.Application.Discounts.Queries;
using ShopRu.Model;
using ShopRu.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Application.Discounts.Handlers
{
    public class GetAlDiscountHandler : IRequestHandler<GetAllDiscountQuery, ResponseDto<List<DiscountDto>>>
    {
        private readonly IShopRuDbContext _shopRuDbContext;

        public GetAlDiscountHandler(IShopRuDbContext shopRuDbContext)
        {
            _shopRuDbContext = shopRuDbContext;
        }
        public async Task<ResponseDto<List<DiscountDto>>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            var discountList = new List<DiscountDto>();
            var discount = _shopRuDbContext.Discounts.ToList();
            foreach (var item in discount)
            {
                var myDiscount = new DiscountDto
                {
                    Id = item.Id,
                    Rate = item.Rate,
                    Type = item.Type
                };

                discountList.Add(myDiscount);
            }

            return new ResponseDto<List<DiscountDto>>
            {
                Message = "List of all Available Discounts",
                Succeeded = true,
                Data = discountList,
                Code = "201"
            };

            

        }
    }
}
