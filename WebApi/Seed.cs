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
                var events = new List<EventDetails>()
                {
                    new EventDetails()
                    {
                        Capacity = 10,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Ebéd",
                    },
                    new EventDetails()
                    {
                        Capacity = 5,
                        Country = "ger",
                        CreationDate = DateTime.Now,
                        Location = "Berlin",
                        Name = "Túra",
                    },
                    new EventDetails()
                    {
                        Capacity = 20,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Gödöllő",
                        Name = "Munka",
                    },
                    new EventDetails()
                    {
                        Capacity = 40,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Hajózás",
                    },
                    new EventDetails()
                    {
                        Capacity = 25,
                        Country = "hun",
                        CreationDate = DateTime.Now,
                        Location = "Budapest",
                        Name = "Heaven",
                    },
                    new EventDetails()
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
