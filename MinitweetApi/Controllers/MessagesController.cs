using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;
using Serilog;

namespace MInitweetApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMessageRepository _messageRepository;
        private readonly IUtilityRepository _utilityRepository;

        public MessagesController(DatabaseContext context, IMessageRepository messageRepository, IUtilityRepository utilityRepository)
        {
            _context = context;
            _messageRepository = messageRepository;
            _utilityRepository = utilityRepository;
        }

        [HttpGet]
        [Route("/public")]
        public async Task<IActionResult> PublicTimeline()
        {
            Log.Information("Public Get - this is a nice test");
            return Ok(await _messageRepository.getPublicTimeline());
            //return new OkObjectResult(_messageRepository.getPublicTimeline());
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> UserTimeline([FromRoute] string username)
        {
            return new OkObjectResult(_messageRepository.GetUserTimeline(username));
        }

        [HttpPost]
        [Route("msgs/{username}")]
        public async Task<IActionResult> AddMessage(int latest, [FromBody] Stringwrapper sw, [FromRoute] string username)
        {

            if (!_messageRepository.newMessage(username, sw.content))
            {
                _utilityRepository.PutLatest(latest);
                return StatusCode(403);
            }
            return NoContent();
        }


        [HttpGet]
        [Route("msgs/{username}")]
        public async Task<IActionResult> GetMessages(int latest, [FromRoute] string username)
        {
            var messages = await _messageRepository.GetUserTimeline(username);
            _utilityRepository.PutLatest(latest);
            if (messages == null) return NoContent();
            return Ok(messages);
        }
        public class Stringwrapper
        {
            public string content { get; set; }
        }

    }
}
