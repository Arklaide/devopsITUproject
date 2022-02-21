using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;
using Newtonsoft.Json.Linq;

namespace MinitweetApi.Controllers
{
    [Route("")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IUserRepository _userRepository;


        public FollowersController(DatabaseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }


        [HttpPost]
        [Route("fllws/{username}")]
        public async Task<IActionResult> fllws([FromBody] FollowDTO fd, string username)
        {

            _userRepository.follows(username, fd.follow);
            return new OkResult();
        }

        



        public class FollowDTO
        {
            public string follow { get; set; }
        }
        public class UnFollowDTO
        {
            public string unfollow { get; set; }
        }
    }
}
