using Contact.Application.Features.Query.Contact;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDict.Common.Models.Enums;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpGet("GetContactsByLocation")]
        public async Task<IActionResult> GetContactByLocation(Location location)
        {
            GetContactsByLocationQuery query = new GetContactsByLocationQuery(location);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
