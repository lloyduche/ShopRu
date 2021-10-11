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
    public class GetDiscountByTypeHandler : IRequestHandler<GetDiscountByTypeQuery, ResponseDto<DiscountDto>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public GetDiscountByTypeHandler(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }
        public async Task<ResponseDto<DiscountDto>> Handle(GetDiscountByTypeQuery request, CancellationToken cancellationToken)
        {
            var IsExist = _shopRuContext.Discounts.FirstOrDefault(x => x.Type == request.DiscountType);

            if(IsExist == null)
            {
                return new ResponseDto<DiscountDto>
                {
                    Message = $"{request.DiscountType} Discount is not available",
                    Succeeded = false,
                    Data = default

                };
            }

            var discount = new DiscountDto
            {
                Id = IsExist.Id,
                Type = IsExist.Type,
                Rate = IsExist.Rate
            };

            return new ResponseDto<DiscountDto>
            {
                Message = $"{request.DiscountType} Discount",
                Data = discount,
                Succeeded = true
            };

        }
    }
}
