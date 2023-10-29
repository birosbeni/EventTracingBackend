namespace EventTracingBackend.BusinessLogic
{
    public interface IEventRepository
    {
        EventDetails GetEvent(Guid id);
        ICollection<EventHead> GetEvents();
        ICollection<EventDetails> GetEventsByLocation(Guid id);
        ICollection<EventDetails> GetEventsByParticipant(Guid id);
        bool CreateEvent(EventDetails _event);
        bool UpdateEvent(EventDetails _event);
        bool DeleteEvent(Guid id);
        bool EventExists(Guid id);

        bool Save();
    }
}
