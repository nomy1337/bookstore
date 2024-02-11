using EventManager.BL.Interfaces;
using EventManager.Models;
using EventManager.Models.Request;
using EventManager.Models.Response;

namespace EventManager.BL.Services
{
    public class EventManagerService : IEventManagerService
    {
        private readonly IMemberService _memberService;

        private readonly IEventService _eventService;

        public EventManagerService(
            IMemberService memberService, 
            IEventService eventService)
        {
            _memberService = memberService;
            _eventService = eventService;
        }

        public void RegisterMemberForEvent(int memberId, int eventId)
        {
            var member = _memberService.GetMemberById(memberId);
            if (member == null)
            {
                return;
            }

            var @event = _eventService.GetEventById(eventId);
            if (@event == null)
            {
                return;
            }

            _eventService.AddMemberToEvent(@event, member);
        }

        public GetEventsForMemberResponse GetEventsForMember(GetEventsForMemberRequest request)
        {
            var member = _memberService.GetMemberById(request.MemberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return new GetEventsForMemberResponse { Events = new List<Event>() };
            }

            var resultEvents = _eventService
                .GetAllEvents()
                .Where(e => e.Members.Any(m => m.Id == member.Id))
                .ToList();

            return new GetEventsForMemberResponse { Events = resultEvents };
        }

        public GetMembersForEventResponse GetMembersForEvent(GetMembersForEventRequest request)
        {
            var @event = _eventService.GetEventById(request.EventId);
            if (@event == null)
            {
                return new GetMembersForEventResponse { Members = new List<Member>() };
            }

            var members = @event.Members;
            return new GetMembersForEventResponse { Members = members }; // Placeholder
        }
    }
}
