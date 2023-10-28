namespace EventTracingBackend.BusinessLogic
{
    public interface IEventRepository
    {
        EventDetails GetEvent(Guid id);
        ICollection<EventHead> GetEvents();
        bool CreateEvent(EventDetails _event);
        bool UpdateEvent(EventDetails _event);
        bool DeleteEvent(EventDetails _event);
        bool EventExists(Guid id);

        bool Save();
    }
}
