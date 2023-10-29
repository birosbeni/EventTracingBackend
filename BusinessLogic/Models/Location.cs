namespace EventTracingBackend.BusinessLogic
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public ICollection<EventHead> EventDetails { get; set; }
    }
}
