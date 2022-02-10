#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;

namespace MinitweetApi.Controllers
{
    [Route("")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FollowersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Followers/5
        [HttpGet("fllws")]
        public async Task<ActionResult<Follower>> GetFollower(string whousername, string whomusername)
        {
            var follower = await _context.Follower.FindAsync();

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }

        // GET: api/Followers/5
        [HttpGet("fllws/{username}")]
        public async Task<ActionResult<Follower>> GetFollowerByUser(string username)
        {
            var user = await _context.User.Where(e => e.username == username).SingleOrDefaultAsync();

            var follower = await _context.Follower.FindAsync();

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }


        // POST: api/Followers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("fllws/{username}")]
        public async Task<ActionResult<Follower>> PostFollower(string username,Follower follower)
        {
            _context.Follower.Add(follower);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FollowerExists(follower.who_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFollower", new { id = follower.who_id }, follower);
        }


        private bool FollowerExists(int id)
        {
            return _context.Follower.Any(e => e.who_id == id);
        }
    }
}
