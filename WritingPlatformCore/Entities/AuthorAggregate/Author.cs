using Ardalis.GuardClauses;
using System.Collections.Generic;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities.AuthorAggregate
{
    public class Author: BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        private List<FixationMethod> _fixationMethods = new List<FixationMethod>();
        public IEnumerable<FixationMethod> FixationMethods => _fixationMethods.AsReadOnly();

        private Author() { }
        public Author(string identity) : this() 
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}
