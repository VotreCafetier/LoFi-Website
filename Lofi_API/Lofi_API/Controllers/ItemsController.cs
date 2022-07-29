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

        public ItemsController(_dbContext context) =>
            _context = context;

        /**
         * 
         * GET: api/Items
         * Get all the items
         * 
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems() =>
            await _context.Items
            .Include(i => i.Itype)
            .ToListAsync();

        /**
         * 
         * GET: api/Items/Locations
         * Get all the locations for the items
         * 
         */
        [HttpGet("Locations")]
        public async Task<ActionResult<IEnumerable<Itype>>> GetLocations() =>
            await _context.Itypes.ToListAsync();

        /**
         * 
         * GET: api/Items/Types
         * Get all the types for the items
         * 
         */
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<Ilocation>>> GetTypes() =>
            await _context.Ilocations.ToListAsync();

        /**
         * 
         * GET: api/Items/5
         * Get an item with its ID
         * @param id long   id of the item
         * 
         */
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var item = await _context.Items.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
