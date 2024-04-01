using Kukelleku.api.Configuration;
using Kukelleku.Dto.VrtNews;
using Kukelleku.Interfaces.Configuration;
using Kukelleku.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace kukelleku.api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class NewsController(
        IVrtNewsService vrtNewsService
        ) : ControllerBase
    {
        private readonly IVrtNewsService _vrtNewsService = vrtNewsService;

        [HttpGet("Vrt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ResponseCache(Duration = 60)] // Cache the response for 60 seconds
        public async Task<ActionResult> GetVrt()
        {
            var articles = await _vrtNewsService.GetArticles();
            if (articles == null)
                return StatusCode(503, "Service Unavailable");

            return Ok(articles);
        }
    }
}
