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
        public DbSet<Follower> Follower{ get; set; }

        public DbSet<User> User{ get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usernames has to be unique for some reason
            modelBuilder.Entity<User>().HasIndex(u => u.username).IsUnique();

            //Reference of many messages having one user
            modelBuilder.Entity<Message>().HasOne<User>(u => u.user).WithMany().HasForeignKey(u => u.author_id);

            //many-to-many relation
            modelBuilder.Entity<Follower>().HasKey(e => new { e.who_id, e.whom_id });

            modelBuilder.Entity<Follower>()
                .HasOne<User>(u => u.who_user)
                .WithMany(u => u.followers)
                .OnDelete(DeleteBehavior.ClientCascade);
        }


    }
}
