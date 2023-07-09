using System.Net;
using System.Threading.Tasks;
using AcmeCorpProject.Application.Tocken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.API.BaseClass;
using SampleProject.Application.Customers;
using SampleProject.Application.Customers.LoginCustomer;
using SampleProject.Application.Customers.RegisterCustomer;

namespace SampleProject.API.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILoginService _loginService;

        public CustomersController(IMediator mediator, ILoginService loginService)
        {
            this._mediator = mediator;
            _loginService = loginService;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody]RegisterCustomerRequest request)
        {
           var customer = await _mediator.Send(new RegisterCustomerCommand(request.Email, request.Name));

           return Created(string.Empty, customer);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResult>> Authenticate(LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginService.Authenticate(login);

            return Ok(result);
        }

        [HttpGet("refresh-token")]
        [Authorize]
        public async Task<ActionResult<TokenResult>> GetRefreshToken()
        {
            var loginId = await GetLoginId();
            var result = await _loginService.GetRefreshToken(loginId);
            return Ok(result);

        }

    }
}
