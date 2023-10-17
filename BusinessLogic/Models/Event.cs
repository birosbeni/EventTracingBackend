using System.ComponentModel.DataAnnotations;

namespace EventTracingBackend.BusinessLogic
{
    public class Event
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A nevet kötelező megadni")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakternek kell lennie a névnek")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter hosszú lehet a név")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "A nevet kötelező megadni")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakternek kell lennie a helyszínnek")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter hosszú lehet a helyszín")]
        public string Location { get; set; }

        public string? Country { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A kapacitán nem lehet negatív")]
        public int? Capacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
