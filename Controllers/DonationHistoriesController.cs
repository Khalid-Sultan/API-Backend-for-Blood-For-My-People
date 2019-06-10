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
    public class DonationHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonationHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonationHistories
        [HttpGet]
        public IEnumerable<DonationHistory> GetdonationHistories()
        {
            return _context.donationHistories.Include(e=>e.donor).Include(e=>e.recepient);
        }

        //GET: api/DonationHistories/donorId
        [HttpGet("{donorId}")]
        public IEnumerable<DonationHistory> GetDonationHistoryByDonorId([FromRoute] int donorId)
        {
            return _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).Where(x => x.donorId == donorId);
        }
        //GET: api/DonationHistories/recepientId
        [HttpGet("{recepientId}")]
        public IEnumerable<DonationHistory> GetDonationHistoryByRecepientId([FromRoute] int recepientId)
        {
            return _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).Where(x => x.donorId == recepientId);
        }



        // GET: api/DonationHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donationHistory = await _context.donationHistories.FindAsync(id);

            if (donationHistory == null)
            {
                return NotFound();
            }

            return Ok(donationHistory);
        }

        // PUT: api/DonationHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationHistory([FromRoute] int id, [FromBody] DonationHistory donationHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donationHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(donationHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            donationHistory = _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).FirstOrDefault(e => e.id == donationHistory.id);
            return Ok(donationHistory);
        }

        // POST: api/DonationHistories
        [HttpPost]
        public async Task<IActionResult> PostDonationHistory([FromBody] DonationHistory donationHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.donationHistories.Add(donationHistory);
            await _context.SaveChangesAsync();
            donationHistory = _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).FirstOrDefault(e => e.id == donationHistory.id);
            return CreatedAtAction("GetDonationHistory", new { id = donationHistory.id }, donationHistory);
        }

        // DELETE: api/DonationHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonationHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donationHistory = await _context.donationHistories.FindAsync(id);
            if (donationHistory == null)
            {
                return NotFound();
            }

            _context.donationHistories.Remove(donationHistory);
            await _context.SaveChangesAsync();

            return Ok(donationHistory);
        }

        private bool DonationHistoryExists(int id)
        {
            return _context.donationHistories.Any(e => e.id == id);
        }
    }
}