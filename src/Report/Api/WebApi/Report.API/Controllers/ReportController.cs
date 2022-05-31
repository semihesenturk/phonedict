using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDict.Common.Models.Enums;
using PhoneDict.Common.Models.RequestModels;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ReportController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetReport([FromQuery] Location location)
        {
            CreateReportCommand createReportCommand = new CreateReportCommand(location);

            var result = await _mediator.Send(createReportCommand);

            return Ok(result);
        }
    }
}
