using System;
using ITB2203Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITB2203Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly DataContext _context;

        public SessionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Session>> GetSessions(string? auditoriumname = null, string? movieTitle = null, DateTime? periodStart = null, DateTime? periodEnd = null)
        {
            IQueryable<Session> query = _context.Sessions;

            if (!string.IsNullOrEmpty(auditoriumname))
                query = query.Where(x => x.AuditoriumName.ToUpper().Contains(auditoriumname.ToUpper()));

            if (movieTitle != null)
                query = query.Where(x => (_context!.Movies!.FirstOrDefault((e) => e.Title == movieTitle)).Id == x.MovieId);

            if (periodStart != null)
                query = query.Where(x => x.StartTime > periodStart);

            if (periodEnd != null)
                query = query.Where(x => x.StartTime < periodEnd);

            return query.ToList();
        }

        [HttpGet("{id}/tickets")]
        public ActionResult<Session> GetSessionTickets(int? ticketNo = null)
        {
            var ticketNo = _context.Tickets.Where(t => t.SessionId == id).ToList();

            if (ticketNo != null)
            {
                query = query.Where(x => (_context!.Movies!.FirstOrDefault((e) => e.Title == movieTitle)).Id == x.MovieId);
                return NotFound("No tickets found for this session.");
            }

            return Ok(tickets);
        }


        [HttpGet("{id}")]
        public ActionResult<Session> GetSession(int id)
        {
            var session = _context.Sessions.Find(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        [HttpPut("{id}")]
        public IActionResult PutSession(int id, Session session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }

            if (session.StartTime > DateTime.Now)
            {
                return BadRequest("Start time must be in the future.");
            }

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sessions.Any(e => e.Id == id))
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
        public ActionResult<Session> PostSession(Session session)
        {
            if (session.StartTime > DateTime.Now)
            {
                return BadRequest("Start time must be in the future.");
            }

            var existingMovie = _context.Movies.Any(m => m.Id == session.MovieId);
            if (!existingMovie)
            {
                return BadRequest("Movie not found.");
            }

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);

            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return Ok();
        }
    }
}
