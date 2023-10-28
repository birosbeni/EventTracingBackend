using System.ComponentModel.DataAnnotations;

namespace EventTracingBackend.BusinessLogic
{
    public class EventDetails : EventHead
    {
        public string? Country { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A kapacitán nem lehet negatív")]
        public int? Capacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
