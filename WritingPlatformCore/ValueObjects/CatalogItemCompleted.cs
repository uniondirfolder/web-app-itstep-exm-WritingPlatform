using Ardalis.GuardClauses;

namespace WritingPlatformCore.ValueObjects
{
    /// <summary>
    /// Represents a snapshot of the item that was completed.
    /// </summary>
    public class CatalogItemCompleted
    {
        public int CatalogItemId { get; private set; }
        public string CompositionName { get; private set; }
        public string PictureUri { get; private set; }
        public string FileTextUri { get; private set; }
        public string FileAudioUri { get; private set; }
        public string Description { get; private set; }
        public uint PageCount { get; private set; }
        public uint Popularity { get; private set; }
        private CatalogItemCompleted()
        {

        }
        public CatalogItemCompleted(int catalogItemId, string compositionName, string pictureUri, string fileTextUri, string fileAudioUri, string description, uint pageCount, uint popularity = 0)
        {
            Guard.Against.OutOfRange(catalogItemId, nameof(catalogItemId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(compositionName, nameof(compositionName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));
            Guard.Against.NullOrEmpty(fileTextUri, nameof(fileTextUri));
            Guard.Against.NullOrEmpty(fileAudioUri, nameof(fileAudioUri));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(popularity, nameof(popularity));
            Guard.Against.NegativeOrZero(pageCount, nameof(pageCount));

            CatalogItemId = catalogItemId;
            CompositionName = compositionName;
            PictureUri = pictureUri;
            FileTextUri = fileTextUri;
            FileAudioUri = fileAudioUri;
            Description = description;
            PageCount = pageCount;
            Popularity = popularity;
        }
    }
}
