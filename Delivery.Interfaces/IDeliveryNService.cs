using System;
using System.Threading.Tasks;

namespace Delivery.Interfaces
{
    public interface IDeliveryNService
    {       
        string SomethingGood(string item);
        Task<bool> IsDeliveredAsync(int memberId);//integration with external service
    }
}
