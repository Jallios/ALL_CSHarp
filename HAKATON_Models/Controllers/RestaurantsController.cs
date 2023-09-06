using HAKATON_Models.Models.Restaurants;
using HAKATON_Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAKATON_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsService _service;

        public RestaurantsController(RestaurantsService Service) =>
            _service = Service;

        [HttpGet]
        public async Task<List<Restaurants>> Get() =>
            await _service.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Restaurants>> Get(string id)
        {
            var restaurants = await _service.GetAsync(id);

            if (restaurants is null)
            {
                return NotFound();
            }

            return restaurants;
        }
    }
}
