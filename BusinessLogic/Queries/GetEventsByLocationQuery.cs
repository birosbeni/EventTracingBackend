using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class GetEventsByLocationQuery : IRequest<List<EventDetails>>
    {
        public Guid LocationId { get; }

        public GetEventsByLocationQuery(Guid locationId)
        {
            LocationId = locationId;
        }
    }
}
