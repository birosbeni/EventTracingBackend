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

        public bool CreateLocation(Location _location)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLocation(Location _location)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(Guid id)
        {
            var foundLocation = context.Locations.Where(e => e.Id == id).FirstOrDefault();
            return foundLocation;
        }

        public ICollection<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public bool LocationExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLocation(Location _location)
        {
            throw new NotImplementedException();
        }
    }
}
