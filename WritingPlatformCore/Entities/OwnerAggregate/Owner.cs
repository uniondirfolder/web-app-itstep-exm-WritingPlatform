using Ardalis.GuardClauses;
using System.Collections.Generic;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities.OwnerAggregate
{
    public class Owner: BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        private List<FixationMethod> _fixationMethods = new();
        public IEnumerable<FixationMethod> FixationMethods => _fixationMethods.AsReadOnly();

        private Owner() { }
        public Owner(string identity) : this() 
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}
