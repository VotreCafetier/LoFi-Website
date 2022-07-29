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
    public class UsersController : ControllerBase
    {
        private readonly _dbContext _context;

        public UsersController(_dbContext context) =>
            _context = context;

        /*
         * 
         * Check if user already exists in db
         * Private method
         * @param id long   the id of the user
         * 
         */
        private async Task<Luser> UserExists(long id)
        {
            var user = await _context.Lusers.FirstOrDefaultAsync(i => i.Userid == id) ?? new Luser { };
            return user;
        }

        /*
         * 
         * api/User/Login
         * Login user
         * 
         */
        //[HttpPost]
        //public async Task<ActionResult> Login()
        //{
        //    return NoContent();
        //}

        /*
         * 
         * api/User/Register
         * Create (Register) user in db 
         * 
         */
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Luser>> Register(Luser luser)
        {
            await _context.Lusers.AddAsync(luser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(UserExists), new { id = luser.Userid }, luser);
        }

        /*
         * 
         * api/User{id}/Update
         * Updates the user
         * 
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Luser luser)
        {
            if (id != luser.Userid)
            {
                return BadRequest();
            }

            _context.Entry(luser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (UserExists(id) == null)
                    return NotFound();
            }

            return NoContent();
        }


        /*
         * 
         * api/User{UserID}/Buy{ItemID}
         * Buy an item
         * 
         */
        //[HttpPost]
        //public async Task<ActionResult> Buy()
        //{
        //    return NoContent();
        //}


        /*
         * 
         * api/User{ID}/Items
         * Buy an item
         * 
         */
        [HttpGet("Items")]
        public async Task<ActionResult> GetUserItems()
        {
            return NoContent();
        }
    }
}
