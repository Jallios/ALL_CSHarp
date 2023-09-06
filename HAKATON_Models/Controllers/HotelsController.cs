using HAKATON_Models.Models.Hotels;
using HAKATON_Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAKATON_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelsService _service;

        public HotelsController(HotelsService Service) =>
            _service = Service;

        [HttpGet]
        public async Task<List<Hotels>> Get() =>
            await _service.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Hotels>> Get(string id)
        {
            var hotels = await _service.GetAsync(id);

            if (hotels is null)
            {
                return NotFound();
            }

            return hotels;
        }

        [HttpGet("Pag")]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotels(int pageNumber, int pageSize)
        {
            var hotels = await _service.GetPag(pageNumber,pageSize);

            if (hotels is null)
            {
                return NotFound();
            }

            return hotels;

        }
    }
}
