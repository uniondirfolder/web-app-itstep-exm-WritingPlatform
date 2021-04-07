using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    public interface ICabinetService
    {
        Task TransferCabinetAsync(string anonymousId, string ownerName);
        Task AddItemToCabinet(int cabinetId, int catalogItemId);
        Task SetDateTimeModify(int cabinetId, Dictionary<string, bool> composition);
        Task DeleteCabinetAsync(int cabinetId);
    }
}
