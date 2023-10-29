using EventTracingBackend.BusinessLogic.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext context;

        public LocationRepository(DataContext context)
        {
            this.context = context;
        }
        public Location GetLocation(Guid id)
        {
            var foundLocation = context.Locations.Where(e => e.Id == id).FirstOrDefault();
            return foundLocation;
        }
        public ICollection<Location> GetLocations()
        {
            var locations = this.context.Locations.ToList();
            return locations;
        }

        public bool CreateLocation(Location _location)
        {
            this.context.Locations.Add(_location);
            return Save();
        }

        public bool UpdateLocation(Location _location)
        {
            this.context.Locations.Update(_location);
            return Save();
        }

        public bool DeleteLocation(Guid id)
        {
            var locationToDelete = context.Locations.Find(id);

            this.context.Locations.Remove(locationToDelete);
            return Save();
        }


        public bool LocationExists(Guid id)
        {
            return this.context.Locations.Any(l => l.Id == id);
        }

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
