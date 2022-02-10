#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;

namespace MInitweetApi.Controllers
{
    [ApiController]
    [Route("")]
    public class MessagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MessagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet("msgs")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessage()
        {
            return await _context.Message.ToListAsync();
        }

        // GET: api/Messages
        [HttpGet("msgs/{username}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagebyUser(string username)
        {
            var user = await _context.User.Where(e => e.username == username).SingleOrDefaultAsync();
            return await _context.Message.Where(e => e.author_id == user.user_Id).ToListAsync();
        }


        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("msgs/{username}")]
        public async Task<ActionResult<Message>> PostMessage(string username, Message message)
        {
            var user = await _context.User.Where(e => e.username == username).SingleOrDefaultAsync();
            message.author_id = user.user_Id;
            message.user = user;
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.message_Id }, message);
        }


        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.message_Id == id);
        }
    }
}
