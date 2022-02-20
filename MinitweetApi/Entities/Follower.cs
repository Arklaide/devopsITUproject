using System.ComponentModel.DataAnnotations;

namespace MInitweetApi.Models
{
    public class Follower
    {
        [Key]
        public Guid who_id{ get; set; }

        public User who_user { get; set; }
        
        public User whom_user { get; set; }
    }
}
