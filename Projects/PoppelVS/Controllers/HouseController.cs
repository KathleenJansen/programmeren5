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
    [Route("api/house")]
    public class HouseController : Controller
    {
		private readonly appDbContext _context;

		public HouseController(appDbContext context)
		{
			_context = context;
		}

		// GET: api/House
		[HttpGet]
        public IEnumerable<House> GetHouse()
        {
            var houses = _context.House.ToList(); //.Include(h => h.Site).ToList();
            return houses;
        }

		//GET: api/House/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetHouse([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var house = await _context.House.SingleOrDefaultAsync(m => m.Id == id);

			if (house == null)
			{
				return NotFound();
			}

			return Ok(house);
		}

		// PUT: api/House/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutHouse([FromRoute] int id, [FromBody] House house)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != house.Id)
			{
				return BadRequest();
			}

			_context.Entry(house).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!HouseExists(id))
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

		// POST: api/House
		[HttpPost]
		public async Task<IActionResult> PostHouse([FromBody] House house)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.House.Add(house);


            await _context.SaveChangesAsync();

		
			return CreatedAtAction("GetHouse", new { id = house.Id }, house);
		}

		// DELETE: api/House/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteHouse([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var house = await _context.House.SingleOrDefaultAsync(m => m.Id == id);
			if (house == null)
			{
				return NotFound();
			}

			_context.House.Remove(house);
			await _context.SaveChangesAsync();

			return Ok(house);
		}

		private bool HouseExists(int id)
		{
			return _context.House.Any(e => e.Id == id);
		}
	}
}