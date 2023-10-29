using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class CreateLocation
    {
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
    }
}
