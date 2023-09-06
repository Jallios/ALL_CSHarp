using HAKATON_Models.Models.Tracks;
using HAKATON_Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAKATON_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly TracksService _service;

        public TracksController(TracksService Service) =>
            _service = Service;

        [HttpGet]
        public async Task<List<Tracks>> Get() =>
            await _service.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Tracks>> Get(string id)
        {
            var tracks = await _service.GetAsync(id);

            if (tracks is null)
            {
                return NotFound();
            }

            return tracks;
        }
    }
}
