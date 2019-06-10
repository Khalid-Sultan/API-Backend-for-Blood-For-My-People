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
    public class RecepientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecepientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Recepients
        [HttpGet]
        public IEnumerable<Recepient> Getrecepients()
        {
            return _context.recepients.Include(e=>e.user);
        }

        // GET: api/Recepients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecepient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recepient = await _context.recepients.FindAsync(id);

            if (recepient == null)
            {
                return NotFound();
            }

            return Ok(recepient);
        }

        // PUT: api/Recepients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepient([FromRoute] int id, [FromBody] Recepient recepient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recepient.id)
            {
                return BadRequest();
            }

            _context.Entry(recepient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            recepient = _context.recepients.Include(e => e.user).FirstOrDefault(e => e.id == recepient.id);
            return Ok(recepient);
        }

        public class Clean
        {
            public string name { get; set; }
            public string location { get; set; }
            public string phoneNumber { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        // POST: api/Recepients
        [HttpPost]
        public async Task<IActionResult> PostRecepient([FromBody] Clean clean)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = new User { email = clean.username, password = clean.password, role = "Recepient" };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            Recepient recepient = new Recepient();
            recepient.name = clean.name;
            recepient.location = clean.location;
            recepient.phoneNumber = clean.phoneNumber;
            recepient.userId = _context.users.FirstOrDefault(x=>x.email== clean.username).id;
            recepient.user = user;
            _context.recepients.Add(recepient);
            await _context.SaveChangesAsync();
            recepient = _context.recepients.Include(e => e.user).FirstOrDefault(e => e.id == recepient.id);

            return CreatedAtAction("GetRecepient", new { id = recepient.id }, recepient);
        }

        // DELETE: api/Recepients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recepient = await _context.recepients.FindAsync(id);
            if (recepient == null)
            {
                return NotFound();
            }

            _context.recepients.Remove(recepient);
            await _context.SaveChangesAsync();

            return Ok(recepient);
        }

        private bool RecepientExists(int id)
        {
            return _context.recepients.Any(e => e.id == id);
        }
    }
}