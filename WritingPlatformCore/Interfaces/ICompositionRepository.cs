
using System.Threading.Tasks;
using WritingPlatformCore.Entities.CompositionAggregate;

namespace WritingPlatformCore.Interfaces
{
    interface ICompositionRepository: IAsyncRepository<Composition>
    {
        Task<Composition> GetByIdWithItemsAsync(int id);
    }
}
