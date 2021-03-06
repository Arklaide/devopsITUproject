using System.ComponentModel.DataAnnotations;

namespace MInitweetApi.Models
{
    public class User
    {
        [Key]
        public int user_Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string pw_hash { get; set; }

        public List<Message> messages { get; set; }

    }

    public class Userdto
        {
            public string username { get; set; }
            public string email { get; set; }
            public string pwd { get; set; }
        }
}
