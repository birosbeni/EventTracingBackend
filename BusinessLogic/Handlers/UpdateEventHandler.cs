using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, bool>
    {
        private readonly ILocationRepository locationRepository;
        private readonly IEventRepository eventRepository;

        public UpdateEventHandler(ILocationRepository locationRepository, IEventRepository eventRepository)
        {
            this.locationRepository = locationRepository;
            this.eventRepository = eventRepository;
        }

        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var location = this.locationRepository.GetLocation(request.LocationId);

            if (location == null)
            {
                return false;
            }

            var eventDetails = new EventDetails()
            {
                Id = request.Id,
                Name = request.Name,
                Capacity = request.Capacity,
                CreationDate = request.CreationDate,
                Location = location,
            };

            if (!this.eventRepository.EventExists(request.Id))
            {
                return false;
            }

            return this.eventRepository.UpdateEvent(eventDetails);
        }
    }
}
