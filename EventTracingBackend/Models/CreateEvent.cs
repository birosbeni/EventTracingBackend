using System.ComponentModel.DataAnnotations;

namespace EventTracingBackend.Models
{
    public class CreateEvent
    {
        [Required(ErrorMessage = "A nevet kötelező megadni")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakternek kell lennie a névnek")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter hosszú lehet a név")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A nevet kötelező megadni")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakternek kell lennie a helyszínnek")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter hosszú lehet a helyszín")]
        public string Location { get; set; }

        public string? Country { get; set; }

        public int? Capacity { get; set; }
    }
}
