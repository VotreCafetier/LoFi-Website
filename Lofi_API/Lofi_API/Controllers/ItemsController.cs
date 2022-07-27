using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lofi_API.Data;
using Lofi_API.Models.Generated;

namespace Lofi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly _dbContext _context;

        public ItemsController(_dbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            return await _context.Items
                .Include(i => i.Itype)
                .ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        private async Task<IActionResult> PutItem(long id, Item item)
        {
            if (id != item.Itemid)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        private async Task<ActionResult<Item>> PostItem(Item item)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set '_dbContext.Items'  is null.");
          }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Itemid }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteItem(long id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(long id)
        {
            return (_context.Items?.Any(e => e.Itemid == id)).GetValueOrDefault();
        }
    }
}
