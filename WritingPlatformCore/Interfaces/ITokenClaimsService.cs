
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string ownerName);
    }
}
