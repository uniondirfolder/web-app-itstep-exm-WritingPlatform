

using Ardalis.Specification;
using WritingPlatformCore.Entities.CompositionAggregate;

namespace WritingPlatformCore.Specifications
{
    class OwnerCompositionsWithItemsSpecification : Specification<Composition>
    {
        public OwnerCompositionsWithItemsSpecification(string ownerId) 
        {
            Query.Where(o => o.OwnerId == ownerId)
                .Include(o => o.CompositionItems)
                    .ThenInclude(i => i.ItemCompleted);
        }
    }
}
