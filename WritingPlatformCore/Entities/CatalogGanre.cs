

using WritingPlatformCore.Interfaces;

namespace WritingPlatformCore.Entities
{
    public class CatalogGanre:BaseEntity, IAggregateRoot
    {
        public string Ganre { get; private set; }

        public CatalogGanre(string ganre)
        {
            Ganre = ganre;
        }
    }
}
