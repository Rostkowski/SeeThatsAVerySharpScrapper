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
        public async Task<IActionResult> ScrapWebsites([FromBody] ScrapParameters scrapParameters)
        {
            var result = await _mediator.Send(new GetDataBasedOnCssSelectorsQuery(scrapParameters));

            return Ok(result);
        }
    }
}
