using EventTracingBackend.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipnatController : Controller
    {
        private readonly IParticipantRepository participantRepository;

        public ParticipnatController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        [HttpGet("participants")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Participant>))]
        public IActionResult GetParticipants()
        {
            var participant = participantRepository.GetParticipants();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(participant);
        }

        [HttpGet("participant-by-event")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Participant>))]
        public IActionResult GetParticipantsByEvent(Guid id)
        {
            var participants = participantRepository.GetParticipantsByEvent(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(participants);
        }

        [HttpGet("participant/{id}")]
        [ProducesResponseType(200, Type = typeof(Participant))]
        [ProducesResponseType(400)]
        public IActionResult GetParticipant(Guid id)
        {
            if (!this.participantRepository.ParticipantExists(id))
                return NotFound();

            var @participant = participantRepository.GetParticipant(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(@participant);
        }

        [HttpPost("create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateParticipant([FromBody] CreateParticipant participantCreate)
        {
            Participant _participant = new Participant()
            {
                Id = Guid.NewGuid(),
                Name = participantCreate.Name,
                Age = participantCreate.Age,
            };

            if (participantCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.participantRepository.CreateParticipant(_participant))
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
        public IActionResult UpdateParticipant(Guid id, [FromBody] UpdateParticipant participant)
        {
            var _participant = new Participant()
            {
                Id = id,
                Name = participant.Name,
                Age = participant.Age,
            };
            if (!this.participantRepository.ParticipantExists(id))
                return NotFound();

            if (_participant == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!this.participantRepository.UpdateParticipant(_participant))
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
        public IActionResult DeleteParticipant(Guid id)
        {
            if (!this.participantRepository.ParticipantExists(id))
                return NotFound();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this.participantRepository.DeleteParticipant(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
