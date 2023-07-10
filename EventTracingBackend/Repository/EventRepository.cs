using EventTracingBackend.Data;
using EventTracingBackend.Interfaces;
using EventTracingBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EventTracingBackend.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext context;

        public EventRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CreateEvent(Event _event)
        {
            this.context.Add(_event);
            return Save();
        }

        public bool DeleteEvent(Event _event)
        {
            this.context.Remove(_event);
            return Save();
        }

        public bool EventExists(Guid id)
        {
            return this.context.EventList.Any(e => e.Id == id);
        }

        public Event GetEvent(Guid id)
        {
            return this.context.EventList.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Event> GetEvents()
        {
            return this.context.EventList.ToList();  
        }

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEvent(Event _event)
        {
            this.context.Update(_event);
            return Save();
        }
    }
}
