#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;

namespace MinitweetApi.Controllers
{
    [Route("")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FollowersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("{who_id}/unfollow")]
        public async void unfollow(int who_id, int whom_id)
        {
            var follow = _context.Follower.Where(u => u.who_id == u.who_id && u.whom_id == whom_id).FirstOrDefault();
            _context.Remove(follow);
            _context.SaveChanges();
        }

        [HttpPost("{who_id}/follow")]
        public async void follow(int who_id, int whom_id)
        {
            var follower = new Follower
            {
                who_id = who_id,
                whom_id = whom_id
            };
            _context.Add(follower);
            _context.SaveChanges();
        }



        private bool FollowerExists(int id)
        {
            return _context.Follower.Any(e => e.who_id == id);
        }
    }
}
