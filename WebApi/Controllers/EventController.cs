using AutoMapper;
using EventTracingBackend.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        public EventController(IEventRepository eventRepository, ILocationRepository locationRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        [HttpGet("events")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EventHead>))]
        public IActionResult GetEvents()
        {
            var events = eventRepository.GetEvents(); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(events);
        }

        [HttpGet("events-by-location")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EventDetails>))]
        public IActionResult GetEventsByLocation(Guid id)
        {
            var events = eventRepository.GetEventsByLocation(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(events);
        }


        [HttpGet("events-by-participant")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EventDetails>))]
        public IActionResult GetEventsByParticipant(Guid id)
        {
            var events = eventRepository.GetEventsByParticipant(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(events);
        }


        [HttpGet("event/{id}")]
        [ProducesResponseType(200, Type = typeof(EventDetails))]
        [ProducesResponseType(400)]
        public IActionResult GetEvent(Guid id)
        {
            if (!this.eventRepository.EventExists(id))
                return NotFound();

            var @event = eventRepository.GetEvent(id);
            if (!ModelState.IsValid)  
            {
                return BadRequest(ModelState);
            }
            return Ok(@event);
        }

        [HttpPost("create-event")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] CreateEvent eventCreate)
        {
            var location = this.locationRepository.GetLocation(eventCreate.LocationId);

            EventDetails _event = new EventDetails() 
            { 
                Id = Guid.NewGuid(),
                Name = eventCreate.Name,
                Capacity = eventCreate.Capacity,
                CreationDate = DateTime.Now,
                Location = location,
            };

            if (eventCreate == null)
                return BadRequest(ModelState);
                
            var _oldEvent = this.eventRepository.GetEvents()
                .Where(e => e.Id == _event.Id)
                .FirstOrDefault();

            if (_oldEvent != null)
            {
                ModelState.AddModelError("", "Event already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.eventRepository.CreateEvent(_event))
            {
                ModelState.AddModelError("", "Something went wrond while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("update-event/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(Guid id, [FromBody] UpdateEvent @event)
        {
            var location = this.locationRepository.GetLocation(@event.LocationId);

            var eventDetails = new EventDetails()
            {
                Id = id,
                Name = @event.Name,
                Capacity = @event.Capacity,
                CreationDate = @event.CreationDate,
                Location = location,
            };

            if (!this.eventRepository.EventExists(id))
                return NotFound();

            if (@event == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!this.eventRepository.UpdateEvent(eventDetails))
            {
                ModelState.AddModelError("", "Something went wrong updating evbent");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("delete-event/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEvent(Guid id)
        {
            if (!this.eventRepository.EventExists(id))
                return NotFound();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.eventRepository.DeleteEvent(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return BadRequest(ModelState);
            }

            return NoContent();  
        }
    }
}
