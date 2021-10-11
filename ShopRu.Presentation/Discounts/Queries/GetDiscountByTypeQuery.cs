using MediatR;
using ShopRu.Application.Discounts.Model;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Discounts.Queries
{
    public record GetDiscountByTypeQuery: IRequest<ResponseDto<DiscountDto>>
    {
        public string DiscountType { get; set; }
    }
}
