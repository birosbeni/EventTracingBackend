using EventTracingBackend.BusinessLogic;

namespace EventTracingBackend
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.EventList.Any())
            {
                var events = new List<Event>()
                {
                    new Event()
                    {
                        Capacity = 10,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Ebéd",
                    },
                    new Event()
                    {
                        Capacity = 5,
                        Country = "ger",
                        CreationDate = DateTime.Now,
                        Location = "Berlin",
                        Name = "Túra",
                    },
                    new Event()
                    {
                        Capacity = 20,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Gödöllő",
                        Name = "Munka",
                    },
                    new Event()
                    {
                        Capacity = 40,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Hajózás",
                    },
                    new Event()
                    {
                        Capacity = 25,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Heaven",
                    },
                    new Event()
                    {
                        Capacity = 11,
                        Country = "teszt",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "teszt",
                    },
                };

                dataContext.EventList.AddRange(events);
                dataContext.SaveChanges();
            
            }
        }
    }
}
