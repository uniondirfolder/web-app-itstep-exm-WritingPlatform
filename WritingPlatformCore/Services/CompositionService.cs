

using Ardalis.GuardClauses;
using System.Linq;
using System.Threading.Tasks;
using WritingPlatformCore.Entities;
using WritingPlatformCore.Entities.CabinetAggregate;
using WritingPlatformCore.Entities.CompositionAggregate;
using WritingPlatformCore.Extensions;
using WritingPlatformCore.Interfaces;
using WritingPlatformCore.Specifications;
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
            var cabSpec = new CabinetWithItemsSpecification(cabinetId);
            var cabinet = await _cabinetRepository.FirstOrDefaultAsync(cabSpec);

            Guard.Against.NullCabinet(cabinetId, cabinet);
            Guard.Against.EmptyCabinetOnReadingException(cabinet.Items);

            var catalogItemsSpecification = new CatalogItemsSpecification(cabinet.Items.Select(item => item.CatalogItemId).ToArray());
            var catalogItems = await _itemRepository.ListAsync(catalogItemsSpecification);

            var items = cabinet.Items.Select(cabinetItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == cabinetItem.Id);
                var itemCompleted = new CatalogItemCompleted(
                    catalogItem.Id,
                    catalogItem.Name,
                    _uriComposer.ComposePicUri(catalogItem.PictureUri),
                    _uriComposer.ComposeFileTextUri(catalogItem.FileTextUri),
                    _uriComposer.ComposeFileAudioUri(catalogItem.FileAudioUri),
                    catalogItem.Description,
                    catalogItem.PageCount,
                    catalogItem.Popularity);
                var compositionItem = new CompositionItem(itemCompleted, 0);
                return compositionItem;
            }).ToList();

            var composition = new Composition(cabinet.OwnerId, items, distanationAddress);

            await _compositionRepository.AddAsync(composition);

        }

    }
}
