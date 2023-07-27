using EventManager.Models;
using EventManager.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KOLController : ControllerBase
    {
        private readonly IKOLRepository _kolRepository;

        public KOLController(IKOLRepository kOLRepository)
        {
            _kolRepository = kOLRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _kolRepository.GetAllKOLsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKOLById([FromRoute] int id)
        {
            var kol = await _kolRepository.GetKOLByIdAsync(id);
            if (kol == null)
            {
                return NotFound();
            }
            return Ok(kol);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewKOL([FromBody] KOLModel kolModel)
        {
            var id = await _kolRepository.AddKOLAsync(kolModel);
            return CreatedAtAction(nameof(GetKOLById), new { id = id, Controller = "kol" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKOL([FromBody] KOLModel kolModel, [FromRoute] int id)
        {
            await _kolRepository.UpdateKOLAsync(id, kolModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKOL([FromRoute] int id)
        {
            await _kolRepository.DeleteKOLAsync(id);
            return Ok();
        }
    }
}
