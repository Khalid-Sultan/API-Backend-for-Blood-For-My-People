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
            IEnumerable<DonationHistory> donationHistories = _context.donationHistories;
            //.Include(e=>e.donor).Include(e=>e.recepient);
            //foreach(DonationHistory donation in donationHistories)
            //{
            //    int? donorId = donation.donorId;
            //    int? recepientId = donation.recepientId;
            //    if (donorId.HasValue && recepientId.HasValue)
            //    {
            //        int donor = donorId.Value;
            //        int recepient = recepientId.Value;
            //        donation.donor.DonationHistories = ByDonor(donor).ToList();
            //        donation.recepient.DonationHistories = ByRecepient(recepient).ToList();
            //        Console.Write(donation);
            //    }
            //}
            return donationHistories;
        }
        // GET: api/Donors/5
        [Route("ByDonor/{donorId}")]
        public IEnumerable<DonationHistory> ByDonor([FromRoute] int donorId)
        {
            return _context.donationHistories.Where(e => e.donorId == donorId);

        }
        // GET: api/Donors/5
        [Route("ByRecepient/{recepientId}")]
        public IEnumerable<DonationHistory> ByRecepient([FromRoute] int recepientId)
        {
            return _context.donationHistories.Where(e => e.recepientId == recepientId);

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
        [HttpGet("{donationHistoryId}")]
        public async Task<IActionResult> GetDonationHistory([FromRoute] int donationHistoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donationHistory = await _context.donationHistories.FindAsync(donationHistoryId);

            if (donationHistory == null)
            {
                return NotFound();
            }

            return Ok(donationHistory);
        }

        // PUT: api/DonationHistories/5
        [HttpPut("{donationHistoryId}")]
        public async Task<IActionResult> PutDonationHistory([FromRoute] int donationHistoryId, [FromBody] DonationHistory donationHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (donationHistoryId != donationHistory.donationHistoryId)
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
                if (!DonationHistoryExists(donationHistoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            donationHistory = _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).FirstOrDefault(e => e.donationHistoryId == donationHistory.donationHistoryId);
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
            donationHistory.date = DateTime.Now.ToShortDateString();
            _context.donationHistories.Add(donationHistory);
            await _context.SaveChangesAsync();
            donationHistory = _context.donationHistories.Include(e => e.donor).Include(e => e.recepient).FirstOrDefault(e => e.donationHistoryId == donationHistory.donationHistoryId);
            return CreatedAtAction("GetDonationHistory", new { donationHistoryId = donationHistory.donationHistoryId }, donationHistory);
        }

        // DELETE: api/DonationHistories/5
        [HttpDelete("{donationHistoryId}")]
        public async Task<IActionResult> DeleteDonationHistory([FromRoute] int donationHistoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donationHistory = await _context.donationHistories.FindAsync(donationHistoryId);
            if (donationHistory == null)
            {
                return NotFound();
            }

            _context.donationHistories.Remove(donationHistory);
            await _context.SaveChangesAsync();

            return Ok(donationHistory);
        }

        private bool DonationHistoryExists(int donationHistoryId)
        {
            return _context.donationHistories.Any(e => e.donationHistoryId == donationHistoryId);
        }
    }
}