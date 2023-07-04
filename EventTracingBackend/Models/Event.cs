namespace EventTracingBackend.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public int Capacity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
