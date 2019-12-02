using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using dwp.ms.demo.registration.Queries;
using Microsoft.Extensions.Logging;
using System.Net;
using dwp.ms.demo.registration.Application.Commands;

namespace dwp.ms.demo.registration.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IRegistrationQueries _registrationQueries;
        private readonly ILogger<RegistrationController> _logger;
        public RegistrationController(
            IMediator mediator,
            IRegistrationQueries registrationQueries,
            ILogger<RegistrationController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _registrationQueries = registrationQueries ?? throw new ArgumentNullException(nameof(registrationQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Registration), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetRegistrationAsync(int id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var registration = await _registrationQueries.GetRegistrationAsync(id);

                return Ok(registration);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> CreateRegistrationAsync([FromBody]CreateRegistrationCommand createRegistrationCommand)
        {
            bool commandResult = false;
            commandResult =  await _mediator.Send(createRegistrationCommand);
            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}