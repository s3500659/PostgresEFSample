using Microsoft.AspNetCore.Mvc;
using PostgresEF.Dtos;
using PostgresEF.Factory;
using PostgresEF.Models.Entities;
using PostgresEF.Models.Interfaces;
using System.Threading.Tasks;

namespace PostgresEF.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToysController : ControllerBase
    {
        private readonly IToyRepository _toyService;
        private readonly IToyFactory _toyFactory;

        public ToysController(IToyRepository toyService, IToyFactory toyFactory)
        {
            _toyService = toyService;
            _toyFactory = toyFactory;
        }

        // GET: api/Toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToyById(int id)
        {
            var toy = await _toyService.GetToyById(id);

            if (toy == null)
                return NotFound();

            return Ok(toy);
        }

        // GETL api/Toys
        [HttpPost]
        public async Task<ActionResult> CreateToy(CreateToyDto createToyDto)
        {
            var toy = _toyFactory.CreateToy();
            toy.Title = createToyDto.Title;

            await _toyService.CreateToy(toy);
            return Ok(toy);
        }


    }
}
