using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Models
{
    public class User
    {
        public int user_Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string pw_hash { get; set; }

        public List<Message> messages { get; set; }
    }
}
