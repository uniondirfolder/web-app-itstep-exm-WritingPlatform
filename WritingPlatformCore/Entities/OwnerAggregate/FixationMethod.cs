
namespace WritingPlatformCore.Entities.OwnerAggregate
{
    public class FixationMethod: BaseEntity
    {
        public bool Text { get; private set; }
        public bool Audio { get; private set; }
        public string ExternalApi { get; private set; }
    }
}
