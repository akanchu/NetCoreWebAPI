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
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            var events = await _eventRepository.GetEventByIdAsync(id);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewEvents([FromBody]EventModel eventModel)
        {
            var id = await _eventRepository.AddEventAsync(eventModel);
            return CreatedAtAction(nameof(GetEventById), new { id = id, Controller = "event" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent([FromBody] EventModel eventModel, [FromRoute]int id)
        {
            await _eventRepository.UpdateEventAsync(id,eventModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            await _eventRepository.DeleteEventAsync(id);
            return Ok();
        }

    }
}
