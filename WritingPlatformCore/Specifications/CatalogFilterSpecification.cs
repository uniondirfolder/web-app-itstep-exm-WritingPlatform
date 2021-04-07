
using Ardalis.Specification;
using WritingPlatformCore.Entities;

namespace WritingPlatformCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? ganreId, int? languageId)
        {
            Query.Where(i => (!ganreId.HasValue || i.CatalogGanreId == ganreId) &&
                (!languageId.HasValue || i.CatalogLanguageId == languageId));
        }
    }
}
