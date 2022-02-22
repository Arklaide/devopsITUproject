using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;

namespace MInitweetApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Follower> Follower { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Utility> Utility { get; set; }




    }
}
