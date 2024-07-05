using AirBnbApi.Models;
using AirBnbApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly ContractsService _contractsService;

        public ContractsController(ContractsService contractsService) =>
            _contractsService = contractsService;

        [HttpGet]
        public async Task<List<Contract>> Get() =>
            await _contractsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Contract>> Get(string id)
        {
            var contract = await _contractsService.GetAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contract newContract)
        {
            await _contractsService.CreateAsync(newContract);

            return CreatedAtAction(nameof(Get), new { id = newContract.Id }, newContract);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Contract updatedContract)
        {
            var contract = await _contractsService.GetAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            updatedContract.Id = contract.Id;

            await _contractsService.UpdateAsync(id, updatedContract);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contract = await _contractsService.GetAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            await _contractsService.RemoveAsync(id);

            return NoContent();
        }
    }
}