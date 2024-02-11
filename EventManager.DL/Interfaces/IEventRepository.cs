using EventManager.Models;

namespace EventManager.DL.Interfaces
{
    public interface IEventRepository
    {
        Event GetById(int id);
        void Add(Event @event);
        void Update(Event @event);
        void Delete(int id);
        
        IEnumerable<Event> GetAllEvents();
    }
}
