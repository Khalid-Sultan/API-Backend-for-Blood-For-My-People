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
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reports
        [HttpGet]
        public IEnumerable<Report> Getreports()
        {
            return _context.reports.Include(e=>e.donationHistory);
        }

        // GET: api/Reports/donorId
        [HttpGet("ByDonor/{donorId}")]
        public IEnumerable<Report> GetReportsByDonorId([FromRoute] int donorId)
        {
            return _context.reports.Include(e => e.donationHistory).Where(e => e.donationHistory.donorId == donorId);
        }
        // GET: api/Reports/recepientId
        [HttpGet("ByRecepient/{recepientId}")]
        public IEnumerable<Report> GetReportsByRecepientId([FromRoute] int recepientId)
        {
            return _context.reports.Include(e => e.donationHistory).Where(e => e.donationHistory.recepientId == recepientId);
        }
        // GET: api/Reports/donationHistoryId
        [HttpGet("ByDonationHistory/{donationHistoryId}")]
        public Report GetReportByDonationHistoryId([FromRoute] int donationHistoryId)
        {
            return _context.reports.Where(e => e.donationHistoryId == donationHistoryId).FirstOrDefault();
        }

        // GET: api/Reports/5
        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetReport([FromRoute] int reportId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _context.reports.FindAsync(reportId);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // PUT: api/Reports/5
        [HttpPut("{reportId}")]
        public async Task<IActionResult> PutReport([FromRoute] int reportId, [FromBody] Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (reportId != report.reportId)
            {
                return BadRequest();
            }

            _context.Entry(report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(reportId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            report = _context.reports.Include(e => e.donationHistory).FirstOrDefault(e => e.reportId == report.reportId);
            return Ok(report);
        }

        // POST: api/Reports
        [HttpPost]
        public async Task<IActionResult> PostReport([FromBody] Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.reports.Add(report);
            await _context.SaveChangesAsync();
            report = _context.reports.Include(e => e.donationHistory).FirstOrDefault(e => e.reportId == report.reportId);
            return CreatedAtAction("GetReport", new { reportId = report.reportId }, report);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{reportId}")]
        public async Task<IActionResult> DeleteReport([FromRoute] int reportId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _context.reports.FindAsync(reportId);
            var donationHistory= _context.donationHistories.FirstOrDefault(x => x.donationHistoryId == report.donationHistoryId);
            _context.donationHistories.Remove(donationHistory);
            await _context.SaveChangesAsync();
            if (report == null)
            {
                return NotFound();
            }

            _context.reports.Remove(report);
            await _context.SaveChangesAsync();

            return Ok(report);
        }

        private bool ReportExists(int reportId)
        {
            return _context.reports.Any(e => e.reportId == reportId);
        }
    }
}