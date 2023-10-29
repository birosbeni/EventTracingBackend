using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class EventParticipant
    {
        public Guid EventId { get; set; }
        public Guid ParticipantId { get; set; }
        public Event Event {  get; set; }
        public Participant Participant { get; set; }
    }
}
