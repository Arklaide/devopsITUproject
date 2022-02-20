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
    [Route("")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("add_message")]
        public async void add_message(int author_id, string text)
        {
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int timestamp = (int)t.TotalSeconds;
            var message = new Message
            {
                author_id = author_id,
                text = text,
                pub_date = timestamp,
                flagged = 0
            };
            _context.Add(message);
            _context.SaveChanges();
        }

        [HttpPost("register")]
        public async void register(string username, string email, string password, string password2)
        {
            var user = new User
            {
                username = username,
                email = email,
                pw_hash = password
            };
            _context.Add(user);
            _context.SaveChanges();
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> login(string username)
        {

            var user = _context.User.Where(u => u.username == username).FirstOrDefault();
            return user; 
        }




    }
}
