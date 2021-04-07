
using System.Threading.Tasks;
using WritingPlatformCore.ValueObjects;

namespace WritingPlatformCore.Interfaces
{
    public interface ICompositionService
    {
        Task CreateComposition(int cabinetId, RecommendGiveAdvice distanationAddress);
    }
}
