using MediatR;
using Microsoft.AspNetCore.Mvc;
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



        [HttpGet("getclientById")]
        [ProducesResponseType(typeof(ResponseDto<object>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetInvoice([FromBody] object id)
        {
            return null;
        }
    }
}
