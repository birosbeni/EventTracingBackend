using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class EventHead
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
