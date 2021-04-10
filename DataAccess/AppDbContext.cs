

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberComment> MemberComments { get; set; }
        public DbSet<MemberStory> MemberStories { get; set; }
        public DbSet<StoryGenre> StoryGenres { get; set; }
        public DbSet<StoryRating> StoryRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Member>()
        }
    }
}
