using HAKATON_Models.Models;
using HAKATON_Models.Models.Routes;
using HAKATON_Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAKATON_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly RoutesService _service;

        public RoutesController(RoutesService Service) =>
            _service = Service;

        [HttpGet]
        public async Task<List<Routes>> Get() =>
            await _service.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Routes>> Get(string id)
        {
            var routes = await _service.GetAsync(id);

            if (routes is null)
            {
                return NotFound();
            }

            return routes;
        }
    }
}
