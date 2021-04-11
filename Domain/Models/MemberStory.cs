

using System.Collections.Generic;

namespace Domain.Entities
{
    public sealed class MemberStory : BaseEntity
    {
        public string ContextUri { get; set; }

        public int RatingId { get; set; }
        public StoryRating Rating { get; set; }

        public ICollection<StoryGenre> Genres{ get; set; }

    }
}
