using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    public interface IUriComposer
    {
        string ComposePicUri(string uriTemplate);
        string ComposeFileTextUri(string uriTemplate);
        string ComposeFileAudioUri(string uriTemplate);
    }
}
