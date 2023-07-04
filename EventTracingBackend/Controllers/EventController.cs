using AutoMapper;
using EventTracingBackend.Dto;
using EventTracingBackend.Interfaces;
using EventTracingBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
        public IActionResult GetEvents()
        {
            var events = this.mapper.Map<List<EventDto>>(eventRepository.GetEvents()); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(events);
        }

        [HttpGet("{location}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
        [ProducesResponseType(400)]
        public IActionResult GetEventsByLocation(string location)
        {
            var events = this.mapper.Map<List<EventDto>>(eventRepository.GetEventsByLocation(location));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Event))]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] Event eventCreate)
        {
            if (eventCreate == null)
                return BadRequest(ModelState);
                
            var _event = this.eventRepository.GetEvents()
                .Where(e => e.Id == eventCreate.Id)
                .FirstOrDefault();

            if (_event != null)
            {
                ModelState.AddModelError("", "Event already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.eventRepository.CreateEvent(eventCreate))
            {
                ModelState.AddModelError("", "Something went wrond while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(Guid id, [FromBody] Event @event)
        {
            if (!this.eventRepository.EventExists(id))
                return NotFound();

            if (@event == null)
                return BadRequest(ModelState);

            if (id != @event.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!this.eventRepository.UpdateEvent(@event))
            {
                ModelState.AddModelError("", "Something went wrong updating evbent");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEvent(Guid id)
        {
            if (!this.eventRepository.EventExists(id))
                return NotFound();


            var eventToDelete = this.eventRepository.GetEvent(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.eventRepository.DeleteEvent(eventToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return BadRequest(ModelState);
            }

            return NoContent();  
        }
    }
}
