using EventManager.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventManagementController : ControllerBase
    {
        private readonly IEventManagementRepository _eventManagementRepository;

        public EventManagementController(IEventManagementRepository eventManagementRepository)
        {
            _eventManagementRepository = eventManagementRepository;
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventDetailById([FromRoute] int id)
        {
            var events = await _eventManagementRepository.GetEventDetailAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpPost("{kolId}/{eventId}")]
        public async Task<IActionResult> AddKOLToEvent([FromRoute] int kolId, [FromRoute] int eventId)
        {
            await _eventManagementRepository.AddKOLToGivenEventAsync(kolId, eventId);
            return Ok();
        }

        [HttpDelete("{kolId}/{eventId}")]
        public async Task<IActionResult> RemoveKOLFromEvent([FromRoute] int kolId, [FromRoute] int eventId)
        {
            await _eventManagementRepository.RemoveKOLFromEventAsync(kolId,eventId);
            return Ok();
        }
    }
}
