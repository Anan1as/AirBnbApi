using AirBnbApi.Models;
using AirBnbApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _housesService;

        public HousesController(HousesService housesService) =>
            _housesService = housesService;

        [HttpGet]
        public async Task<List<House>> Get() =>
            await _housesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<House>> Get(string id)
        {
            var house = await _housesService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        [HttpPost]
        public async Task<IActionResult> Post(House newHouse)
        {
            await _housesService.CreateAsync(newHouse);

            return CreatedAtAction(nameof(Get), new { id = newHouse.Id }, newHouse);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, House updatedHouse)
        {
            var house = await _housesService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            updatedHouse.Id = house.Id;

            await _housesService.UpdateAsync(id, updatedHouse);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var house = await _housesService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            await _housesService.RemoveAsync(id);

            return NoContent();
        }
    }
}