using HAKATON_Models.Models.Tours;
using HAKATON_Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAKATON_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ToursService _service;

        public ToursController(ToursService Service) =>
            _service = Service;

        [HttpGet]
        public async Task<List<Tours>> Get() =>
            await _service.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Tours>> Get(string id)
        {
            var tours = await _service.GetAsync(id);

            if (tours is null)
            {
                return NotFound();
            }

            return tours;
        }
    }
}
