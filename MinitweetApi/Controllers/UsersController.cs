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
        public async Task<ActionResult> register(string username, string email, string password, string password2)
        {
            var user = new User
            {
                username = username,
                email = email,
                pw_hash = password
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




    }
}
