using Domain.Entities;
using DomainServices.Interfaces;


namespace DomainServices.Implementation
{
    public class MemberAnemicService : IMemberAnemicService
    {
        public decimal GetRating(Member member)
        {
            decimal result = 0.0m;
            if (null == member) return result;
            if (null == member.Stories) return result;
            if (0 == member.Stories.Count) return result;

            foreach (var item in member.Stories)
            {
                result += item.Rating.CurrentValue;
            }
            return result /= member.Stories.Count;
        }
    }
}
