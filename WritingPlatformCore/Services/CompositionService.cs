

using System.Threading.Tasks;
using WritingPlatformCore.Entities;
using WritingPlatformCore.Entities.CabinetAggregate;
using WritingPlatformCore.Entities.CompositionAggregate;
using WritingPlatformCore.Interfaces;
using WritingPlatformCore.ValueObjects;


namespace WritingPlatformCore.Services
{
    public class CompositionService
    {
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        private readonly IAsyncRepository<Composition> _compositionRepository;      
        private readonly IAsyncRepository<Cabinet> _cabinetRepository;
        private readonly IUriComposer _uriComposer;
        public CompositionService(IAsyncRepository<Cabinet> cabinetRepository, IAsyncRepository<CatalogItem> itemRepository, IAsyncRepository<Composition> compositionRepository, IUriComposer uriComposer)
        {
            _cabinetRepository = cabinetRepository;
            _itemRepository = itemRepository;
            _compositionRepository = compositionRepository;
            _uriComposer = uriComposer;
        }

        public async Task CreateCompositionAsync(int cabinetId, RecommendGiveAdvice distanationAddress) 
        {

        }

    }
}
