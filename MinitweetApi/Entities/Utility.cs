using System.ComponentModel.DataAnnotations;

namespace MInitweetApi.Models
{
    public class Utility
    {
        [Key] 
        public int id {
            get;
            set;
        }
        public int LATEST { get; set; }
    }
}