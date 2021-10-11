using MediatR;
using ShopRu.Application.Discounts.Commands;
using ShopRu.Domain.Discount;
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
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, ResponseDto<string>>
    {
        private readonly IShopRuDbContext _shopRuContext;

        public CreateDiscountHandler(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }
        public async Task<ResponseDto<string>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var IsExist = _shopRuContext.Discounts.FirstOrDefault(x => x.Type == request.createDiscountDto.Type || x.Rate == request.createDiscountDto.Rate);

            if(IsExist != null)
            {
                return new ResponseDto<string>
                {
                    Message = $"Discount Package Already exist",
                    Data = null,
                    Succeeded = false
                };
            }

            


            var conv = new Discount
            {
                Rate = request.createDiscountDto.Rate,
                Type = request.createDiscountDto.Type
            };

            await _shopRuContext.Discounts.AddAsync(conv);
            await _shopRuContext.SaveChangesAsync();

            return new ResponseDto<string>
            {
                Message = "Discount created Successfully",
                Succeeded = true,
                Data = "Discount Type : " + conv.Type
            };
        }
    }
}
