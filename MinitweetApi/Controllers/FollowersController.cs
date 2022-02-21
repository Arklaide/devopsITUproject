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
        public async Task<IActionResult> fllws(string username, [FromBodyAttribute] FllwDTO fllwDto)
        {
            if (fllwDto.follow != string.Empty)
            {

                if (!_userRepository.Follow(username, fllwDto.follow))
                {
                    return NotFound();
                }
            }
            else if (fllwDto.unfollow != string.Empty)
            {

                if (_userRepository.Unfollow(username, fllwDto.unfollow))
                {
                    return NoContent();
                }
            }
            else
                return BadRequest();

            return NoContent();
        }

        public class FllwDTO
        {
            public string? follow { get; set; }
            public string? unfollow { get; set; }
        }
    }
}
