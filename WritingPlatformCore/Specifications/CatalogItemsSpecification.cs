using Ardalis.Specification;
using System;
using System.Linq;
using WritingPlatformCore.Entities;

namespace WritingPlatformCore.Specifications
{
    public class CatalogItemsSpecification : Specification<CatalogItem>
    {
        public CatalogItemsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
