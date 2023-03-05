using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeeThatsAVerySharpScrapper.Models;
using SeeThatsAVerySharpScrapper.Queries.GetDataBasedOnCssSelectors;

namespace SeeThatsAVerySharpScrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ScrapController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ScrapWebsites([FromBody] ScrapParameters requestParameters)
        {
            var result = await _mediator.Send(new GetDataBasedOnCssSelectorsQuery(requestParameters));

            return Ok(result);
        }
    }
}
