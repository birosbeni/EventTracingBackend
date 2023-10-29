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
                var locations = new List<Location>
                {
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        Country = "Magyarország",
                        PostalCode = 1234,
                        City = "Budapest",
                        Street = "Kossuth utca",
                        House = 1
                    },
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        Country = "Olaszország",
                        PostalCode = 3454,
                        City = "Roma",
                        Street = "Asd street",
                        House = 1
                    },
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        Country = "Kína",
                        PostalCode = 12345,
                        City = "Peking",
                        Street = "Kossuth utca",
                        House = 1
                    },
                };

                dataContext.Locations.AddRange(locations);
                dataContext.SaveChanges();

                var participants = new List<Participant>
                {
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dávid Nagy",
                        Age = 25
                    },
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Eszter Kovács",
                        Age = 43
                    },
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bence Tóth",
                        Age = 22
                    },
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Csilla Szabó",
                        Age = 54
                    },
                };

                dataContext.Participants.AddRange(participants);
                dataContext.SaveChanges();

                var events = new List<Event>
                {
                    new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Konferencia",
                        Capacity = 100,
                        CreationDate = DateTime.Now,
                        Location = locations[0],
                        EventParticipants = new List<EventParticipant>
                        {
                            new EventParticipant
                            {
                                ParticipantId = participants[0].Id
                            },
                            new EventParticipant
                            {
                                ParticipantId = participants[1].Id
                            }
                        }
                    },
                    new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Csapatépítő",
                        Capacity = 20,
                        CreationDate = DateTime.Now,
                        Location = locations[1],
                        EventParticipants = new List<EventParticipant>
                        {
                            new EventParticipant
                            {
                                ParticipantId = participants[1].Id
                            },
                            new EventParticipant
                            {
                                ParticipantId = participants[2].Id
                            }
                        }
                    },
                    new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Előadás",
                        Capacity = 30,
                        CreationDate = DateTime.Now,
                        Location = locations[2],
                        EventParticipants = new List<EventParticipant>
                        {
                            new EventParticipant
                            {
                                ParticipantId = participants[2].Id
                            },
                            new EventParticipant
                            {
                                ParticipantId = participants[3].Id
                            }
                        }
                    },
                };

                dataContext.EventList.AddRange(events);
                dataContext.SaveChanges();

            }
        }
    }
}
