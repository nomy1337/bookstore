using EventManager.BL.Interfaces;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMemberService _memberService;

        public EventController(IMemberService memberService, IEventService eventService)
        {
            _eventService = eventService;
            _memberService = memberService;
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] Event @event)
        {
            _eventService.AddEvent(@event);
            return CreatedAtAction(nameof(GetEventById), new { id = @event.Id }, @event);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _eventService.UpdateEvent(@event);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpPost("{eventId}/members/{memberId}")]
        public IActionResult AddMemberToEvent(int eventId, int memberId)
        {
            var @event = _eventService.GetEventById(eventId);
            if (@event == null)
            {
                return NotFound("Event not found.");
            }

            var member = _memberService.GetMemberById(memberId);
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            _eventService.AddMemberToEvent(@event, member);
            return NoContent();
        }
    }
}
