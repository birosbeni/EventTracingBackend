using EventTracingBackend.Models;

namespace EventTracingBackend.Interfaces
{
    public interface IEventRepository
    {
        Event GetEvent(Guid id);
        ICollection<Event> GetEvents();
        bool CreateEvent(Event _event);
        bool UpdateEvent(Event _event);
        bool DeleteEvent(Event _event);
        bool EventExists(Guid id);

        bool Save();
    }
}
