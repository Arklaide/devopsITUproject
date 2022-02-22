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
            return new OkObjectResult(_messageRepository.getPublicTimeline());
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> UserTimeline([FromRoute] string username)
        {
            return new OkObjectResult(_messageRepository.GetUserTimeline(username));
        }
        
        [HttpPost]
        [Route("msgs/{username}")]
        public async Task<IActionResult> addMessage([FromBody] Stringwrapper sw, [FromRoute] string username, int latest)
        {
            _messageRepository.newMessage(username, sw.content);
            _utilityRepository.PutLatest(latest);
            return NoContent();
        }


        [HttpGet]
        [Route("msgs/{username}")]
        public async Task<IActionResult> getMessages([FromRoute] string username, int latest)
        {
            var res = _messageRepository.GetUserTimeline(username);
            _utilityRepository.PutLatest(latest);
            return new OkObjectResult(res);
        }
        public class Stringwrapper
        {
            public string content { get; set; }
        }

    }
}
