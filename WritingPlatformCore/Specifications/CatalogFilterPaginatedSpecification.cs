

using Ardalis.Specification;
using WritingPlatformCore.Entities;

namespace WritingPlatformCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        [System.Obsolete]
        public CatalogFilterPaginatedSpecification(int skip, int take, int? ganreId, int? languageId) 
        {
            Query
                .Where(q => (!ganreId.HasValue || q.CatalogGanreId == ganreId) &&
                (!languageId.HasValue || q.CatalogLanguageId == languageId))
                .Paginate(skip, take);
        }
    }
}
