using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopRu.Application.Invoices.Model;
using ShopRu.Application.Invoices.Queries;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRu.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("GenerateInvoice")]
        [ProducesResponseType(typeof(ResponseDto<InvoiceDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetInvoice([FromBody] CreateInvoiceDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new GenerateInvoiceQuery {  CreateInvoiceDto = model});
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
