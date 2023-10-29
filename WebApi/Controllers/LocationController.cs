using EventTracingBackend.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationRepository locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet("locations")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        public IActionResult GetLocations()
        {
            var locations = locationRepository.GetLocations();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations);
        }


        [HttpGet("locations/{id}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocation(Guid id)
        {
            if (!this.locationRepository.LocationExists(id))
                return NotFound();

            var _location = locationRepository.GetLocation(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_location);
        }

        [HttpPost("create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] CreateLocation locationToCreate)
        {
            Location _location = new Location()
            {
                Id = Guid.NewGuid(),
                Country = locationToCreate.Country,
                City = locationToCreate.City,
                House = locationToCreate.House,
                PostalCode = locationToCreate.PostalCode,
                Street = locationToCreate.Street
            };

            if (locationToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.locationRepository.CreateLocation(_location))
            {
                ModelState.AddModelError("", "Something went wrond while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateParticipant(Guid id, [FromBody] UpdateLocation _location)
        {
            var newLocation = new Location()
            {
                Id = id,
                Country = _location.Country,
                City = _location.City,
                House= _location.House,
                PostalCode = _location.PostalCode,
                Street = _location.Street                
            };
            if (!this.locationRepository.LocationExists(id))
                return NotFound();

            if (newLocation == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!this.locationRepository.UpdateLocation(newLocation))
            {
                ModelState.AddModelError("", "Something went wrong updating participant");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLocation(Guid id)
        {
            if (!this.locationRepository.LocationExists(id))
                return NotFound();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.locationRepository.DeleteLocation(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
