using EventTracingBackend.BusinessLogic.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventTracingBackend.BusinessLogic
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext context;
        private readonly IParticipantRepository participantRepository;

        public EventRepository(DataContext context, IParticipantRepository participantRepository)
        {
            this.context = context;
            this.participantRepository = participantRepository;
        }

        public ICollection<EventHead> GetEvents()
        {
            return this.context.EventList.Select(e => new EventHead
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location
            })
        .ToList();
        }

        public ICollection<EventDetails> GetEventsByLocation(Guid id)
        {
            return context.EventList.Where(e => e.Location.Id == id).Select(e => new EventDetails
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location,
                Capacity = e.Capacity,
                CreationDate = e.CreationDate,
            }).ToList();
        }

        public ICollection<EventDetails> GetEventsByParticipant(Guid id)
        {
            return context.EventParticipants
              .Where(ep => ep.ParticipantId == id)
              .Select(ep => new EventDetails
              {
                  Id = ep.Event.Id,
                  Name = ep.Event.Name,
                  Capacity= ep.Event.Capacity,
                  CreationDate = ep.Event.CreationDate,
                  Location = ep.Event.Location,
              })
              .ToList();
        }

        public EventDetails GetEvent(Guid id)
        {
            var foundEvent = context.EventList.Where(e => e.Id == id).Include(l => l.Location).Select(e => new EventDetails
            {
                Id = e.Id,
                Name = e.Name,
                Capacity = e.Capacity,
                CreationDate = e.CreationDate,
                Location = new Location() { Id = e.Location.Id, Country = e.Location.Country, PostalCode = e.Location.PostalCode, City = e.Location.City, Street = e.Location.Street, House = e.Location.House },
            }).FirstOrDefault();
            var eventDetails = new EventDetails { Name = foundEvent.Name, Capacity = foundEvent.Capacity, CreationDate = foundEvent.CreationDate, Id = id, Location = foundEvent.Location };
            return eventDetails;
        }

        public bool CreateEvent(EventDetails _event)
        {
            var newEvent = new Event()
            {
                Id = _event.Id,
                Name = _event.Name,
                Location = _event.Location,
                Capacity = _event.Capacity,
                CreationDate = _event.CreationDate,
            };
            this.context.EventList.Add(newEvent);
            return Save();
        }

        public bool UpdateEvent(EventDetails _event)
        {
            var newEvent = new Event()
            {
                Id = _event.Id,
                Name = _event.Name,
                Location = _event.Location,
                Capacity = _event.Capacity,
                CreationDate = _event.CreationDate,
            };
            this.context.Update(newEvent);
            return Save();
        }

        public bool DeleteEvent(Guid id)
        {
            var _e = this.GetEvent(id);
            var eventToDelete = new Event() 
            { 
                Id = _e.Id,
                Name = _e.Name,
                Capacity = _e.Capacity,
                CreationDate = _e.CreationDate,
                Location = _e.Location,
            };

            var eventParticipantsToDelete = context.EventParticipants.Where(ep => ep.EventId == id);

            this.context.EventList.Remove(eventToDelete);
            this.context.EventParticipants.RemoveRange(eventParticipantsToDelete);
            return Save();
        }

        public bool AddEventToParticipant(Guid eventId, Guid participantId)
        {
            var eventParticipant = new EventParticipant
            {
                EventId = eventId,
                ParticipantId = participantId
            };

            this.context.EventParticipants.Add(eventParticipant);
            return Save();
        }

        public bool EventExists(Guid id)
        {
            return this.context.EventList.Any(e => e.Id == id);
        }

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool EventParticipnatExists(Guid eventId, Guid participantId)
        {
            var ep = this.context.EventParticipants.Where(ep => ep.ParticipantId == participantId && ep.EventId == eventId).FirstOrDefault();
            return ep != null;
        }
    }
}
