using EventManager.Models;
using EventManager.Models.Request;
using EventManager.Models.Response;

namespace EventManager.BL.Interfaces
{
    public interface IEventManagerService
    {
        void RegisterMemberForEvent(int memberId, int eventId);
        GetEventsForMemberResponse GetEventsForMember(GetEventsForMemberRequest request);
        GetMembersForEventResponse GetMembersForEvent(GetMembersForEventRequest request);
    }
}
