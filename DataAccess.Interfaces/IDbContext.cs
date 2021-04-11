

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDbContext
    {
        DbSet<Member> Members { get; }
        DbSet<MemberComment> MemberComments { get; }
        DbSet<MemberStory> MemberStories { get; }
        DbSet<StoryGenre> StoryGenres { get; }
        DbSet<StoryRating> StoryRatings { get; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
