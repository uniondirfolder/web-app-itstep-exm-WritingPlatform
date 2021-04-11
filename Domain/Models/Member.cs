


using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public sealed class Member : BaseEntity
    {
        public Enums.SystemStatus SystemStatus { get; set; }
        public ICollection<MemberStory> Stories { get; set; }
        public ICollection<MemberComment> Comments { get; set; }

        public decimal GetRating() 
        {
            decimal result = Stories.Sum(q => q.Rating.CurrentValue);
            result /= Comments.Count;
            return result;
        }
    }
}
