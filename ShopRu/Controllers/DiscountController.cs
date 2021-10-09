using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopRu.Application.Discounts.Model;
using ShopRu.Domain.Discount;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRu.Controllers
{

    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get Discount
        [HttpGet("AllDiscount")]
        [ProducesResponseType(typeof(List<DiscountDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Get(string id)
        {
            return null;
        }


        [HttpGet("DiscountType")]
        [ProducesResponseType(typeof(DiscountDto), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetDiscountType(string Type)
        {
            return null;
        }

        #endregion


        #region Post Request

        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDto<DiscountDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] Discount model)
        {
            return null;
        }

        #endregion
    }
}
