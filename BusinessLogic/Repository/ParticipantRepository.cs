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

        public bool CreateParticipant(Participant _event)
        {
            throw new NotImplementedException();
        }

        public bool DeleteParticipant(Participant _event)
        {
            throw new NotImplementedException();
        }

        public Participant GetParticipant(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Participant> GetParticipants()
        {
            throw new NotImplementedException();
        }

        public ICollection<Participant> GetParticipantsByEvent(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool ParticipantExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateParticipant(Participant _event)
        {
            throw new NotImplementedException();
        }
    }
}
