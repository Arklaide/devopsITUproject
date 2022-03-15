#nullable disable
using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;
using Prometheus;

namespace MInitweetApi.Controllers
{
    [Route("")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUtilityRepository _utilityRepository;
        
        // metrics
        private static readonly Counter RegistrationCounter = 
            Metrics.CreateCounter("registratition_counter", "Number of created registrations");
        
        private static readonly Counter LoginCounter = 
            Metrics.CreateCounter("login_counter", "Number of logged in users");

        public UsersController(DatabaseContext context, IUserRepository userRepository, IUtilityRepository utilityRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _utilityRepository = utilityRepository;
        }

        [HttpPost("add_message")]
        public async void add_message(int author_id, string text)
        {

        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> register(int latest, [FromBody] Userdto u)
        {
            var created = _userRepository.registerUser(u);
            if (!created) return BadRequest();
            _utilityRepository.PutLatest(latest);
            RegistrationCounter.Inc();
            return NoContent();
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> login(string username)
        {

            var user = _context.User.Where(u => u.username == username).FirstOrDefault();
            LoginCounter.Inc();
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
