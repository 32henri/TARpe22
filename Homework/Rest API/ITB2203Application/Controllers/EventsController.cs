using ITB2203Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITB2203Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly DataContext _context;

    public EventsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetEvents(string? name = null, string? location = null)
    {
        var query = _context.Events!.AsQueryable();

        if (name != null)
            query = query.Where(x => x.Name != null && x.Name.ToUpper().Contains(name.ToUpper()));

        if (location != null)
            query = query.Where(x => x.Location != null && x.Location.ToUpper().Contains(location.ToUpper()));

        return query.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<TextReader> GetEvent(int id)
    {
        var testevent = _context.Events!.Find(id);

        if (testevent == null)
        {
            return NotFound();
        }

        return Ok(testevent);
    }

    [HttpPut("{id}")]
    public IActionResult PutEvent(int id, Event testevent)
    {
        var dbEvent = _context.Events!.AsNoTracking().FirstOrDefault(x => x.Id == testevent.Id);
        if (id != testevent.Id || dbEvent == null)
        {
            return NotFound();
        }

        _context.Update(testevent);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    public ActionResult<Event> PostEvent(Event testevent)
    {
        var dbExercise = _context.Events!.Find(testevent.Id, testevent.Name, testevent.Location);
        if (dbExercise == null)
        {
            _context.Add(testevent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEvent), new { Id = testevent.Id }, testevent);
        }
        else
        {
            return Conflict();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEvent(int id)
    {
        var testevent = _context.Events!.Find(id);
        if (testevent == null)
        {
            return NotFound();
        }

        _context.Remove(testevent);
        _context.SaveChanges();

        return NoContent();
    }
}