using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPIv1.Models;

namespace BookStoreAPIv1.Controllers
{
    [Route("api/coupons")]
    [ApiController]
    public class CouponsAPIController : ControllerBase
    {
        private readonly BookStoreDBContext _context;

        public CouponsAPIController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/CouponsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupons>>> GetCoupons()
        {
            return await _context.Coupons.ToListAsync();
        }

        // GET: api/CouponsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupons>> GetCoupons(string id)
        {
            var coupons = await _context.Coupons.FindAsync(id);

            if (coupons == null)
            {
                return NotFound();
            }

            return coupons;
        }

        // PUT: api/CouponsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupons(int id, Coupons coupons)
        {
            if (id != coupons.CoId)
            {
                return BadRequest();
            }

            _context.Entry(coupons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponsExists(id))
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

        // POST: api/CouponsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coupons>> PostCoupons(Coupons coupons)
        {
            _context.Coupons.Add(coupons);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CouponsExists(coupons.CoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoupons", new { id = coupons.CoId }, coupons);
        }

        // DELETE: api/CouponsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coupons>> DeleteCoupons(string id)
        {
            var coupons = await _context.Coupons.FindAsync(id);
            if (coupons == null)
            {
                return NotFound();
            }

            _context.Coupons.Remove(coupons);
            await _context.SaveChangesAsync();

            return coupons;
        }

        private bool CouponsExists(int id)
        {
            return _context.Coupons.Any(e => e.CoId == id);
        }
    }
}
