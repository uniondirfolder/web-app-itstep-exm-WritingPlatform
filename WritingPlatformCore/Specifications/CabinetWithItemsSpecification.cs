

using Ardalis.Specification;
using WritingPlatformCore.Entities.CabinetAggregate;

namespace WritingPlatformCore.Specifications
{
    public sealed class CabinetWithItemsSpecification: Specification<Cabinet>
    {
        public CabinetWithItemsSpecification(int cabinetId) 
        {
            Query
                .Where(c => c.Id == cabinetId)
                .Include(c => c.Items);
        }
        public CabinetWithItemsSpecification(string ownerId)
        {
            Query
                .Where(o => o.OwnerId == ownerId)
                .Include(o => o.Items);
        }
    }
}
