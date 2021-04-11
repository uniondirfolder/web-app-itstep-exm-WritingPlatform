using Delivery.Interfaces;
using Domain.Entities;
using DomainServices.Interfaces;


namespace DomainServices.Implementation
{
    public class MemberAnemicService : IMemberAnemicService
    {
        private readonly IDeliveryNService _deliveryNService;

        public MemberAnemicService(IDeliveryNService deliveryNService)
        {
            _deliveryNService = deliveryNService;
        }

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

            var mdl = result /= member.Stories.Count;

            if (_deliveryNService.SomethingGood(mdl.ToString()) == "Bad") mdl = 0;//🎃

            return mdl;

            
        }
    }
}
