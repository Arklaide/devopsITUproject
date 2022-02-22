using System.ComponentModel.DataAnnotations;

namespace MInitweetApi.Models
{
    public class Message
    {
        [Key]
        public int message_Id { get; set; }
        public string text { get; set; }
        public DateTime pub_date { get; set; }
        public bool flagged { get; set; }
        public User user { get; set; } 
        public int author_id { get; set; }


    }
}
