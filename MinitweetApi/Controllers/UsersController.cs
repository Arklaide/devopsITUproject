﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;

namespace MInitweetApi.Controllers
{
    [Route("")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(DatabaseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpPost("add_message")]
        public async void add_message(int author_id, string text)
        {
            
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> register([FromBody] Userdto u)
        {
            var user = new User
            {
                username = u.username,
                email = u.email,
                pw_hash = u.pwd
            };
            _context.Add(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> login(string username)
        {

             var user = _context.User.Where(u => u.username == username).FirstOrDefault();
            return user; 
        }


        public class Userdto
        {
            public string username { get; set; }
            public string email { get; set; }
            public string pwd { get; set; }


        }

    }
}
