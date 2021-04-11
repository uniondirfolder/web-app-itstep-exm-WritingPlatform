using Delivery.Interfaces;
using System;
using System.Threading.Tasks;

namespace Delivery.CompanyN
{
    public class DeliveryNService : IDeliveryNService
    {
        public Task<bool> IsDeliveredAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public string SomethingGood(string item)
        {
            throw new NotImplementedException();
        }
    }
}
