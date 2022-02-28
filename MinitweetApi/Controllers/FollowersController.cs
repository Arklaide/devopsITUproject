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
        private readonly IUtilityRepository _utilityRepository;


        public FollowersController(DatabaseContext context, IUserRepository userRepository, IUtilityRepository utilityRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _utilityRepository = utilityRepository;
        }

        [HttpPost]
        [Route("fllws/{username}")]
        public async Task<IActionResult> Fosllow(int latest, [FromRoute] string username, [FromBodyAttribute] FllwDTO fllwDto)
        {
            try
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
                        return NoContent();
                    }
                }
                else
                    return BadRequest();

                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }

        public class FllwDTO
        {
            public string? follow { get; set; }
            public string? unfollow { get; set; }
        }
    }
}
