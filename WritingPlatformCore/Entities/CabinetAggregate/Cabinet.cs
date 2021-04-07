
using System;
using System.Collections.Generic;
using System.Linq;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities.CabinetAggregate
{
    public class Cabinet: BaseEntity, IAggregateRoot
    {
        public string OwnerId { get; private set; }
        private readonly List<CabinetItem> _items = new List<CabinetItem>();
        public IReadOnlyCollection<CabinetItem> Items => _items.AsReadOnly();

        public Cabinet(string ownerId)
        {
            OwnerId = ownerId;
        }

        public void AddItem(int catalogItemId, bool modify=false) 
        {
            if (!modify && !Items.Any(q => q.CatalogItemId == catalogItemId)) 
            {
                _items.Add(new CabinetItem(catalogItemId));
                return;
            }
            var existingItem = Items.FirstOrDefault(q => q.CatalogItemId == catalogItemId);
            existingItem.SetIsModify();
        }

        public void SetNewOwnerId(string ownerId) 
        {
            OwnerId = ownerId;
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.DateTimeCreate == i.DateTimeModify);
        }
    }
}
