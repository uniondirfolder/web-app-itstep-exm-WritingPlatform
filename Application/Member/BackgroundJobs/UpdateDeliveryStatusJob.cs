using DataAccess.Interfaces;
using Delivery.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

/*
 * interactor or usecase
 */
namespace Mobile.UseCases.Member.BackgroundJobs
{
    public class UpdateDeliveryStatusJob : IJob
    {
        private readonly IDbContext _dbContext;
        private readonly IDeliveryNService _deliveryNService;
        public UpdateDeliveryStatusJob(IDbContext dbContext, IDeliveryNService deliveryNService)
        {
            _dbContext = dbContext;
            _deliveryNService = deliveryNService;
        }

        public async Task ExecuteAsync() 
        {
            var members = await _dbContext.Members
                .Where(q => q.SystemStatus == Domain.Enums.SystemStatus.Off)
                .ToListAsync();

            var items = members.Select(q => new { Member = q, Task = _deliveryNService.IsDeliveredAsync(q.Id) }).ToList();

            await Task.WhenAll(items.Select(q => q.Task));

            foreach (var item in items)
            {
                if (item.Task.Result) item.Member.SystemStatus = Domain.Enums.SystemStatus.On;//🧨
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
