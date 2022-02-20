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
    [ApiController]
    [Route("")]
    public class MessagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MessagesController(DatabaseContext context)
        {
            _context = context;
        }

        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.message_Id == id);
        }
    }
}
