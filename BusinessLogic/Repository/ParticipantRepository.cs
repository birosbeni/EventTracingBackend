using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DataContext context;

        public ParticipantRepository(DataContext context)
        {
            this.context = context;
        }

        public Participant GetParticipant(Guid id)
        {
            var participant = this.context.Participants.Where(p => p.Id == id).FirstOrDefault();
            return participant;
        }

        public ICollection<Participant> GetParticipants()
        {
            var participants = this.context.Participants.ToList();
            return participants;
        }

        public ICollection<Participant> GetParticipantsByEvent(Guid eventId)
        {
            var participants = this.context.EventParticipants
                .Where(ep => ep.EventId == eventId)
                .Select(ep => ep.Participant)
                .ToList();
            return participants;
        }

        public bool CreateParticipant(Participant _participant)
        {
            this.context.Participants.Add(_participant);
            return Save();
        }

        public bool UpdateParticipant(Participant _participant)
        {
            this.context.Participants.Update(_participant);
            return Save();
        }

        public bool DeleteParticipant(Guid id)
        {
            var participantToDelete = context.Participants.Find(id);

            var eventParticipantsToDelete = context.EventParticipants.Where(ep => ep.ParticipantId == id);

            this.context.Participants.Remove(participantToDelete);
            this.context.EventParticipants.RemoveRange(eventParticipantsToDelete);
            return Save();
        }

        public bool ParticipantExists(Guid id)
        {
            return this.context.Participants.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
