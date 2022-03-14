using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Models
{
    public class Follower
    {
        public Guid who_id { get; set; }

        public User who_user { get; set; }

        public User whom_user { get; set; }
    }
}
