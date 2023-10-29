using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class UpdateEvent
    {
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public int Capacity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
