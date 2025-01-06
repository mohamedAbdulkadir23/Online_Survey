using Microsoft.EntityFrameworkCore;
using Online_Survey.Models;
namespace Online_Survey.Data
{
    public class OnlineDbCon : DbContext
    {
        public OnlineDbCon(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Address>Addresses { get; set; }
        public DbSet<People> People { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Questions> Questions { get; set; }

        public DbSet<Answers> Answers { get; set; }

    }
}
