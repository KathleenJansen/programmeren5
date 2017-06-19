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
    [Route("api/Site")]
    public class siteController : Controller
    {
        private readonly appDbContext _context;

        public siteController(appDbContext context)
        {
            _context = context;
        }

        // GET: api/Site
        [HttpGet]
        public IEnumerable<Site> GetSite()
        {
            return _context.Site;
        }

        // GET: api/Site/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _context.Site.SingleOrDefaultAsync(m => m.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Site/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite([FromRoute] int id, [FromBody] Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != site.Id)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Site
        [HttpPost]
        public async Task<IActionResult> PostSite([FromBody] Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Site.Add(site);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = site.Id }, site);
        }

        // DELETE: api/Site/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _context.Site.SingleOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Site.Remove(location);
            await _context.SaveChangesAsync();

            return Ok(location);
        }

        private bool LocationExists(int id)
        {
            return _context.Site.Any(e => e.Id == id);
        }
    }
}