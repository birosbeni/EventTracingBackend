namespace EventTracingBackend.BusinessLogic
{
    public interface ILocationRepository
    {
        Location GetLocation(Guid id);
        ICollection<Location> GetLocations();
        bool CreateLocation(Location _location);
        bool UpdateLocation(Location _location);
        bool DeleteLocation(Guid id);
        bool LocationExists(Guid id);

        bool Save();
    }
}
