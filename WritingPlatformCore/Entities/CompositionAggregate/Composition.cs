
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using WritingPlatformCore.Entities;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.CompositionAggregate.Entities
{
    public class Composition:BaseEntity, IAggregateRoot
    {
        private Composition()
        {

        }
        public Composition(string ownerId, List<CatalogItem> items)
        {
            Guard.Against.NullOrEmpty(ownerId, nameof(ownerId));
            Guard.Against.Null(items, nameof(items));

            OwnerId = ownerId;
            _catalogItems = items;
        }
        public string OwnerId { get; private set; }

        public DateTimeOffset DatePublished { get; private set; } = DateTimeOffset.Now;

        private readonly List<CatalogItem> _catalogItems = new();

        public IReadOnlyCollection<CatalogItem> CatalogItems => _catalogItems.AsReadOnly();

        public uint TotalPages() 
        {
            var total=0u;
            foreach (var item in _catalogItems)
            {
                total += item.PageCount;
            }
            return total;
        }

        public uint TotalPopularity()
        {
            var total = 0u;
            foreach (var item in _catalogItems)
            {
                total += item.Popularity;
            }
            return total;
        }

        public int TotalPublication()
        {
            int i = 0;
            while (i<_catalogItems.Count)
            {
                i++;
            }
            return i;
        }
    }
}
