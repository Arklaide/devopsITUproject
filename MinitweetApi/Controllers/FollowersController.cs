using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;

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
            if (string.IsNullOrEmpty(fllwDto.unfollow))
            {

                if (!_userRepository.Follow(username, fllwDto.follow))
                {
                    return NotFound();
                }
            }
            else if (string.IsNullOrEmpty(fllwDto.follow))
            {

                if (!_userRepository.Unfollow(username, fllwDto.unfollow))
                {
                    return NotFound();
                }
            } else
            {
                return StatusCode(404);
            }
            return NoContent();
        }

        public class FllwDTO
        {
            public string? follow { get; set; }
            public string? unfollow { get; set; }
        }
    }
}
