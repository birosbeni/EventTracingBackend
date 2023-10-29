namespace EventTracingBackend.BusinessLogic
{
    public interface IParticipantRepository
    {
        Participant GetParticipant(Guid id);
        ICollection<Participant> GetParticipants();
        ICollection<Participant> GetParticipantsByEvent(Guid id);
        bool CreateParticipant(Participant _event);
        bool UpdateParticipant(Participant _event);
        bool DeleteParticipant(Participant _event);
        bool ParticipantExists(Guid id);

        bool Save();
    }
}
