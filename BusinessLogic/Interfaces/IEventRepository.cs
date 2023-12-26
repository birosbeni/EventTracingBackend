namespace EventTracingBackend.BusinessLogic
{
    public interface IEventRepository
    {
        EventDetails GetEvent(Guid id);
        ICollection<EventHead> GetEvents(string eventName = null, string sortBy = "name", string sortOrder = "asc", int page = 1, int pageSize = 10);
        ICollection<EventDetails> GetEventsByLocation(Guid id);
        ICollection<EventDetails> GetEventsByParticipant(Guid id);
        bool CreateEvent(EventDetails _event);
        bool UpdateEvent(EventDetails _event);
        bool DeleteEvent(Guid id);
        bool AddEventToParticipant(Guid eventId, Guid participantId);
        bool EventExists(Guid id);
        bool EventParticipnatExists(Guid eventId, Guid participantId);
        bool Save();
    }
}
