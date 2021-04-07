

using Ardalis.GuardClauses;
using System;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities
{
    public class CatalogItem: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public uint PageCount { get; private set; }
        public uint Popularity { get; private set; }
        public string PictureUri { get; private set; }
        public string FileTextUri { get; private set; }
        public string FileAudioUri { get; private set; }

        public int CatalogGanreId { get; private set; }
        public CatalogGanre CatalogGanre { get; private set; }

        public int CatalogLanguageId { get; private set; }
        public CatalogLanguage CatalogLanguage { get; private set; }

        public CatalogItem(
            int catalogGanreId,
            int catalogLanguageId,
            string name,
            string description,
            string pictureUri,
            string fileTextUri,
            string fileAudioUri, 
            uint pageCount, 
            uint popularity)
        {
            CatalogGanreId = catalogGanreId;
            CatalogLanguageId = catalogLanguageId;
            Name = name;
            Description = description;
            PictureUri = pictureUri;
            FileTextUri = fileTextUri;
            FileAudioUri = fileAudioUri;
            PageCount = pageCount;
            Popularity = popularity;
        }

        public void UpdateGanre(int catalogGanreId) 
        {
            Guard.Against.Zero(catalogGanreId, nameof(catalogGanreId));
            CatalogGanreId = catalogGanreId;
        }
        public void UpdateLanguage(int catalogLanguageId)
        {
            Guard.Against.Zero(catalogLanguageId, nameof(catalogLanguageId));
            CatalogGanreId = catalogLanguageId;
        }
        public void UpdateDiscription(string description) 
        {
            if (string.IsNullOrEmpty(description))
            {
                Description = string.Empty;
                return;
            }
            Description = description;
        }
        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
                return;
            }
            PictureUri = $"images\\compositions\\{pictureName}?{new DateTime().Ticks}";
        }
        public void UpdateTextBodyUri(string fileTextUri)
        {
            if (string.IsNullOrEmpty(fileTextUri))
            {
                FileTextUri = string.Empty;
                return;
            }
            FileTextUri = fileTextUri;
        }
        public void UpdateAudioBodyUri(string fileAudioUri)
        {
            if (string.IsNullOrEmpty(fileAudioUri))
            {
                FileTextUri = string.Empty;
                return;
            }
            FileTextUri = fileAudioUri;
        }

        public void UpdatePopularity(uint popularity) 
        {
            Guard.Against.NegativeOrZero(popularity, nameof(popularity));
            Popularity = popularity;
        }
        public void UpdatePageCount(uint pageCount)
        {
            Guard.Against.NegativeOrZero(pageCount, nameof(pageCount));
            PageCount = pageCount;
        }
    }
}
