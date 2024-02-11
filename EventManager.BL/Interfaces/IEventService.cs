using EventManager.Models;

namespace EventManager.BL.Interfaces
{
    public interface IEventService
    {
        Event GetEventById(int id);
        void AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(int id);
        IEnumerable<Event> GetAllEvents();

        void AddMemberToEvent(Event @event, Member member);
    }
}
