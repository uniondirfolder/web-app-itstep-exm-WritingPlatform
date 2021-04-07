
using System.Threading.Tasks;
using WritingPlatformCore.CompositionAggregate.Entities;

namespace WritingPlatformCore.Interfaces
{
    interface ICompositionRepository: IAsyncRepository<Composition>
    {
        Task<Composition> GetByIdWithItemsAsync(int id);
    }
}
