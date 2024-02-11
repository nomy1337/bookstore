using EventManager.DL.Interfaces;
using EventManager.DL.MemoryDatabase;
using EventManager.Models;

namespace EventManager.DL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events;

        public EventRepository()
        {
            _events = InMemoryDatabase.EventData;
        }

        public Event GetById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Event @event)
        {
            _events.Add(@event);
        }

        public void Update(Event @event)
        {
            var existingEvent = GetById(@event.Id);
            if (existingEvent != null)
            {
                existingEvent.Title = @event.Title;
                existingEvent.Description = @event.Description;
                existingEvent.StartTime = @event.StartTime;
                existingEvent.EndTime = @event.EndTime;
                existingEvent.Location = @event.Location;
            }
        }

        public void Delete(int id)
        {
            var eventToRemove = GetById(id);
            if (eventToRemove != null)
            {
                _events.Remove(eventToRemove);
            }
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }
    }
}
