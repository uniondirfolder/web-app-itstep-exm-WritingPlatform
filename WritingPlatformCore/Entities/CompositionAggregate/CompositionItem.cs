using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatformCore.ValueObjects;

namespace WritingPlatformCore.Entities.CompositionAggregate
{
    public class CompositionItem: BaseEntity
    {
        public CatalogItemCompleted  CatalogItemCompleted { get; private set; }
        public int NowReading { get; private set; }
        private CompositionItem()
        {
            //EF
        }
        public CompositionItem(CatalogItemCompleted catalogItemCompleted = null, int nowReading = 0)
        {
            CatalogItemCompleted = catalogItemCompleted;
            NowReading = nowReading;
        }
    }
}
