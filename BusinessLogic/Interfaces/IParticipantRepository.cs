namespace EventTracingBackend.BusinessLogic
{
    public interface IParticipantRepository
    {
        Participant GetParticipant(Guid id);
        ICollection<Participant> GetParticipants();
        ICollection<Participant> GetParticipantsByEvent(Guid eventId);
        bool CreateParticipant(Participant _event);
        bool UpdateParticipant(Participant _event);
        bool DeleteParticipant(Guid id);
        bool ParticipantExists(Guid id);

        bool Save();
    }
}
