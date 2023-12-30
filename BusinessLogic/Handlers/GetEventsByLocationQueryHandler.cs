using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic.Handlers
{
    public class GetEventsByLocationQueryHandler : IRequestHandler<GetEventsByLocationQuery, List<EventDetails>>
    {
        private readonly DataContext _context;

        public GetEventsByLocationQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EventDetails>> Handle(GetEventsByLocationQuery request, CancellationToken cancellationToken)
        {
            var events = await _context.EventList
                .Where(e => e.Location.Id == request.LocationId)
                .Select(e => new EventDetails
                {
                    Id = e.Id,
                    Name = e.Name,
                    Location = e.Location,
                    Capacity = e.Capacity,
                    CreationDate = e.CreationDate,
                })
                .ToListAsync(cancellationToken);

            return events;
        }
    }
}
