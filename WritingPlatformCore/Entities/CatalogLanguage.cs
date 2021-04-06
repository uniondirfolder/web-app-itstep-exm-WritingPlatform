using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatformCore.Entities
{
    public class CatalogLanguage
    {
        public string Language { get; private set; }

        public CatalogLanguage(string language)
        {
            Language = language;
        }
    }
}
