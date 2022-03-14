using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Models
{
    public class Message
    {
            public int message_Id { get; set; }
            public string text { get; set; }
            public DateTime pub_date { get; set; }
            public bool flagged { get; set; }
            public User user { get; set; }
            public int author_id { get; set; }

    }
}
