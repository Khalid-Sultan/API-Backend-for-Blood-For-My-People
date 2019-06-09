using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodDonation.Data;
using BloodDonation.Models;

namespace Blood_Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Donors
        [HttpGet]
        public IEnumerable<Donor> Getdonors()
        {
            return _context.donors.Include(e=>e.user);
        }

        // GET: api/Donors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donor = await _context.donors.FindAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }
        // GET: api/Donors/5
        [Route("ByUser/{id}")]
        public IEnumerable<Donor>  ByUser([FromRoute] int id)
        {
            return _context.donors.Where(e => e.userId == id).Include(e => e.user);

        }

        // PUT: api/Donors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonor([FromRoute] int id, [FromBody] Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donor.id)
            {
                return BadRequest();
            }

            _context.Entry(donor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            donor = _context.donors.Include(e => e.user).FirstOrDefault(e => e.id == donor.id);
            return Ok(donor);
        }

        // POST: api/Donors
        [HttpPost]
        public async Task<IActionResult> PostDonor([FromBody] Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.donors.Add(donor);
            await _context.SaveChangesAsync();
            donor = _context.donors.Include(e => e.user).FirstOrDefault(e => e.id == donor.id);
            return CreatedAtAction("GetDonor", new { id = donor.id }, donor);
        }

        // DELETE: api/Donors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donor = await _context.donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            _context.donors.Remove(donor);
            await _context.SaveChangesAsync();

            return Ok(donor);
        }

        private bool DonorExists(int id)
        {
            return _context.donors.Any(e => e.id == id);
        }
    }
}