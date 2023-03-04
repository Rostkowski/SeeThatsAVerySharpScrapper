using Microsoft.AspNetCore.Mvc;
using SeeThatsAVerySharpScrapper.Models;

namespace SeeThatsAVerySharpScrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> ScrapWebsites([FromBody] ScrapParameters scrapParameters)
        {
            HttpClient client = new();

            var result = await client.GetStreamAsync(scrapParameters.Url);

            return Ok(result);
        }
    }
}
