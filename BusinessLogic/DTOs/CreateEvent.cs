using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
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
        public Location Location { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A kapacitán nem lehet negatív")]
        public int Capacity { get; set; }
    }
}
