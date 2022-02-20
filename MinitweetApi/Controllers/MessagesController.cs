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
            _messageRepository.newMessage(username, sw.text);
            return NoContent();
        }


        [HttpGet]
        [Route("msgs/{username}")]
        public async Task<IActionResult> getMessages(string username)
        {
            return new OkObjectResult(_messageRepository.GetUserTimeline(username));
        }
        public class Stringwrapper
        {
            public string text { get; set; }
        }

    }
}
