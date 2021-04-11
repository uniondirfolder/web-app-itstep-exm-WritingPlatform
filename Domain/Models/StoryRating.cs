

using System.Collections.Generic;

namespace Domain.Entities
{
    public sealed class StoryRating : BaseEntity
    {
        private decimal _currentValue;

        public decimal CurrentValue
        {
            get { CalculateRating(); return _currentValue; }
            set { _currentValue = value; }
        }

        public ICollection<MemberComment> Comments { get; set; }

        public void CalculateRating() 
        {
            _currentValue = Comments.Count;
        }
    }
}
