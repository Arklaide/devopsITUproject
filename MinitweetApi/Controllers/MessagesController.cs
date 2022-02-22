using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;

namespace MInitweetApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMessageRepository _messageRepository;

        public MessagesController(DatabaseContext context, IMessageRepository messageRepository)
        {
            _context = context;
            _messageRepository = messageRepository;
        }

        [HttpGet]
        [Route("/public")]
        public async Task<IActionResult> PublicTimeline()
        {
            return new OkObjectResult(_messageRepository.getPublicTimeline());
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> UserTimeline(string username)
        {
            return new OkObjectResult(_messageRepository.GetUserTimeline(username));
        }

        [HttpPost]
        [Route("msgs/{username}")]
        public async Task<IActionResult> addMessage([FromBody] Stringwrapper sw, string username)
        {
            if (!_messageRepository.newMessage(username, sw.content))
            {
                return StatusCode(403);
            }
            return NoContent();
        }


        [HttpGet]
        [Route("msgs/{username}")]
        public async Task<IActionResult> getMessages(string username)
        {
            var messages = await _messageRepository.GetUserTimeline(username);
            if (messages == null) return NoContent();
            return Ok(messages);
        }
        public class Stringwrapper
        {
            public string content { get; set; }
        }

    }
}
