


using System.Collections.Generic;

namespace Domain.Entities
{
    public sealed class Member : BaseEntity
    {
        public Enums.SystemStatus SystemStatus { get; set; }
        public ICollection<MemberStory> Stories { get; set; }
        public ICollection<MemberComment> Comments { get; set; }
    }
}
