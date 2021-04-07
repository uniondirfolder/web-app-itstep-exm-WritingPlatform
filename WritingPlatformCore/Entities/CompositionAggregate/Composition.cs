
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using WritingPlatformCore.Entities;
using WritingPlatformCore.Interfaces;
using WritingPlatformCore.ValueObjects;

namespace WritingPlatformCore.Entities.CompositionAggregate
{
    public class Composition:BaseEntity, IAggregateRoot
    {
        private Composition()
        {

        }
        public Composition(string ownerId, List<CompositionItem> items, RecommendGiveAdvice address)
        {
            Guard.Against.NullOrEmpty(ownerId, nameof(ownerId));
            Guard.Against.Null(items, nameof(items));

            OwnerId = ownerId;
            _compositionItem = items;
            Address = address;
        }
        public string OwnerId { get; private set; }

        public DateTimeOffset DatePublished { get; private set; } = DateTimeOffset.Now;

        private readonly List<CompositionItem> _compositionItem = new();

        public RecommendGiveAdvice Address { get; private set; }

        public IReadOnlyCollection<CompositionItem> CompositionItems => _compositionItem.AsReadOnly();

        public uint TotalPages() 
        {
            var total=0u;
            foreach (var item in _compositionItem)
            {
                total += item.ItemCompleted.PageCount;
            }
            return total;
        }

        public uint TotalPopularity()
        {
            var total = 0u;
            foreach (var item in _compositionItem)
            {
                total += item.ItemCompleted.Popularity;
            }
            return total;
        }

        public int TotalPublication()
        {
            int i = 0;
            while (i< _compositionItem.Count)
            {
                i++;
            }
            return i;
        }
    }
}
