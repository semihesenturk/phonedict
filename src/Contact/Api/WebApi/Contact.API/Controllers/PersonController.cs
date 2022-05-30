using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDict.Common.Models.RequestModels;
using System.Net;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Operations
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        [Route("Contacts/{id}")]
        public async Task<IActionResult> GetPersonContacts(Guid id)
        {
            return Ok();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            var result = _mediator.Send(command);

            return Ok(result.Result.ToString());
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            DeletePersonCommand deletePersonCommand = new DeletePersonCommand(id);

            var result = _mediator.Send(deletePersonCommand).Result;

            return Ok(result);
        }
        #endregion
    }
}
