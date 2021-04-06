

using Ardalis.GuardClauses;
using System;
using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities
{
    class CatalogItem: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
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
            string fileAudioUri)
        {
            CatalogGanreId = catalogGanreId;
            CatalogLanguageId = catalogLanguageId;
            Name = name;
            Description = description;
            PictureUri = pictureUri;
            FileTextUri = fileTextUri;
            FileAudioUri = fileAudioUri;
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
    }
}
