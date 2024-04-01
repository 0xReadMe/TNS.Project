using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBackEnd.Database;

namespace TestBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly PostgresContext _context;

        public SubscribersController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/Subscribers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriber>>> GetSubscribers()
        {
            return await _context.Subscribers.ToListAsync();
        }

        // GET: api/Subscribers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriber>> GetSubscriber(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return subscriber;
        }

        // PUT: api/Subscribers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriber(int id, Subscriber subscriber)
        {
            if (id != subscriber.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
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

        // POST: api/Subscribers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscriber>> PostSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriberExists(subscriber.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubscriber", new { id = subscriber.Id }, subscriber);
        }

        // DELETE: api/Subscribers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscribers.Any(e => e.Id == id);
        }
    }
}
