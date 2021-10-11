using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopRu.Application.Discounts.Commands;
using ShopRu.Application.Discounts.Model;
using ShopRu.Application.Discounts.Queries;
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
        [ProducesResponseType(typeof(ResponseDto<List<DiscountDto>>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllDiscountQuery());
            return Ok(result);
        }


        [HttpGet("DiscountType")]
        [ProducesResponseType(typeof(ResponseDto<DiscountDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetDiscountType(string type)
        {
            var result = await _mediator.Send(new GetDiscountByTypeQuery{ DiscountType = type });
            return Ok(result);
        }

        #endregion


        #region Post Request

        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] CreateDiscountDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateDiscountCommand { createDiscountDto = model });
                return Ok(result);
            }


            return BadRequest();
        }

        #endregion
    }
}
