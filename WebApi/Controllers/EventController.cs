using AutoMapper;
using EventTracingBackend.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.WebApi.Controllers
{
    [Route("api/events")]
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

        [HttpGet("{id}")]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] CreateEvent eventCreate)
        {
            EventDetails _event = new EventDetails();
            _event.Id = Guid.NewGuid();
            _event.Name = eventCreate.Name;
            _event.Location = eventCreate.Location;
            _event.Capacity = eventCreate.Capacity;
            _event.CreationDate = DateTime.Now;

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

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(Guid id, [FromBody] EventDetails @event)
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
