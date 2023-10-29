using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
        public int Capacity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
