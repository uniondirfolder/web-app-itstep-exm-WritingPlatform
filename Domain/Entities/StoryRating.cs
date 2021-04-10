

using System.Collections.Generic;

namespace Domain.Entities
{
    public sealed class StoryRating : BaseEntity
    {
        public decimal CurrentValue { get; set; }
        public ICollection<MemberComment> Comments { get; set; }
    }
}
