using ITB2203Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ITB2203Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeakersController : ControllerBase
    {
        private readonly DataContext _context;

        public SpeakersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Speaker>> GetSpeakers(string? name = null)
        {
            var query = _context.Speakers.AsQueryable();

            if (name != null)
                query = query.Where(x => x.Name != null && x.Name.ToUpper().Contains(name.ToUpper()));

            return query.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Speaker> GetSpeaker(string id)
        {
            var speaker = _context.Speakers.Find(id);

            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }

        [HttpPut("{id}")]
        public IActionResult PutSpeaker(string id, Speaker speaker)
        {
            if (id != speaker.Name)
            {
                return BadRequest();
            }

            _context.Entry(speaker).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Speakers.Any(e => e.Name == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Speaker> PostSpeaker(Speaker speaker)
        {
            var dbSpeaker = _context.Speakers.Find(speaker.Name);
            if (dbSpeaker != null)
            {
                return Conflict();
            }

            _context.Speakers.Add(speaker);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSpeaker), new { id = speaker.Name }, speaker);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpeaker(string id)
        {
            var speaker = _context.Speakers.Find(id);
            if (speaker == null)
            {
                return NotFound();
            }

            _context.Speakers.Remove(speaker);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
