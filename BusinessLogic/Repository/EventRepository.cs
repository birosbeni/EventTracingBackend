using EventTracingBackend;
using System.Runtime.CompilerServices;

namespace EventTracingBackend.BusinessLogic
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext context;

        public EventRepository(DataContext context)
        {
            this.context = context;
        }

        public ICollection<EventHead> GetEvents()
        {
            return this.context.EventList.Select(e => new EventHead
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location,
            })
        .ToList();
        }

        public EventDetails GetEvent(Guid id)
        {
            return this.context.EventList.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool CreateEvent(EventDetails _event)
        {
            this.context.Add(_event);
            return Save();
        }

        public bool UpdateEvent(EventDetails _event)
        {
            this.context.Update(_event);
            return Save();
        }

        public bool DeleteEvent(EventDetails _event)
        {
            this.context.Remove(_event);
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

    }
}
