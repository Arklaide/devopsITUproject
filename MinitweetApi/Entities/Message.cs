using System.ComponentModel.DataAnnotations;

namespace MInitweetApi.Models
{
    public class Message
    {
        [Key]
        public int message_Id { get; set; }
        [Required]
        public int author_id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public int pub_date { get; set; }
        [Required]
        public User user { get; set; } 

        public int flagged { get; set; }

    }
}
