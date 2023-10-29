using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class EventDetails : EventHead
    {
        public int Capacity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
