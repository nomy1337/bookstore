using EventManager.BL.Interfaces;
using EventManager.DL.Interfaces;
using EventManager.Models;

namespace EventManager.BL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event GetEventById(int id)
        {
            return _eventRepository.GetById(id);
        }

        public void AddEvent(Event @event)
        {
            _eventRepository.Add(@event);
        }

        public void UpdateEvent(Event @event)
        {
            _eventRepository.Update(@event);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public void AddMemberToEvent(Event @event, Member member)
        {
            @event.Members.Add(member); 
        }
    }
}
