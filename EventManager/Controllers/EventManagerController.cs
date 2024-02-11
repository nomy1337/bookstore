using EventManager.BL.Interfaces;
using EventManager.Models.Request;
using EventManager.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [ApiController]
    [Route("api/eventmanager")]
    public class EventManagerController : ControllerBase
    {
        private readonly IEventManagerService _eventManagerService;

        public EventManagerController(IEventManagerService eventManagerService)
        {
            _eventManagerService = eventManagerService;
        }

        [HttpPost("register/{memberId}/event/{eventId}")]
        public IActionResult RegisterMemberForEvent(int memberId, int eventId)
        {
            _eventManagerService.RegisterMemberForEvent(memberId, eventId);
            return NoContent();
        }

        [HttpGet("events/{memberId}")]
        public GetEventsForMemberResponse GetEventsForMember(GetEventsForMemberRequest request)
        {
            var response = _eventManagerService.GetEventsForMember(request);
            return response;
        }

        [HttpGet("members/{eventId}")]
        public GetMembersForEventResponse GetMembersForEvent(GetMembersForEventRequest request)
        {
            var response = _eventManagerService.GetMembersForEvent(request);
            return response;
        }
    }
}
