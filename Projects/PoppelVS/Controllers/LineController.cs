using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoppelProject.Models;

namespace PoppelProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Lines")]
    public class LineController : Controller
    {
        private readonly appDbContext _context;

        public LineController(appDbContext context)
        {
            _context = context;
        }

        // GET: api/Lines
        [HttpGet]
        public IEnumerable<Line> GetLine()
        {
            return _context.Line;
        }

        // GET: api/Lines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var line = await _context.Line.SingleOrDefaultAsync(m => m.Id == id);

            if (line == null)
            {
                return NotFound();
            }

            return Ok(line);
        }

        // PUT: api/Lines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLine([FromRoute] int id, [FromBody] Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != line.Id)
            {
                return BadRequest();
            }

            _context.Entry(line).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineExists(id))
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

        // POST: api/Lines
        [HttpPost]
        public async Task<IActionResult> PostLine([FromBody] Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Line.Add(line);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLine", new { id = line.Id }, line);
        }

        // DELETE: api/Lines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var line = await _context.Line.SingleOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            _context.Line.Remove(line);
            await _context.SaveChangesAsync();

            return Ok(line);
        }

        private bool LineExists(int id)
        {
            return _context.Line.Any(e => e.Id == id);
        }
    }
}