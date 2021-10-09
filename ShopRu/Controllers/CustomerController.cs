using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopRu.Application.Customers.Commands;
using ShopRu.Application.Customers.Models;
using ShopRu.Application.Customers.Queries;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ShopRu.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

            
        
        #region Get Request


        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(typeof(ResponseDto<List<CustomerDto>>), 200)]
        [ProducesResponseType(typeof(string),500)]
        public async Task<IActionResult> GetAll()
        {
              var result = await _mediator.Send(new GetAllCustomerQuery());
              return Ok(result);

        }


        [HttpGet("GetCustomerById")]
        [ProducesResponseType(typeof(ResponseDto<CustomerDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery{Id = id });
            return Ok(result);
        }

        [HttpGet("GetClientByName")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _mediator.Send(new GetCustomerByNameQuery { Name = name });
            return Ok(result);
        }

        #endregion




        #region Post Request

        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto model) 
        {
            
                if (ModelState.IsValid)
                {
                    var result = await _mediator.Send(new CreateCustomerCommand { CreateCustomerDto = model });
                    return Ok(result);
                }
            
            
                return BadRequest();
        }

        #endregion
    }
}
