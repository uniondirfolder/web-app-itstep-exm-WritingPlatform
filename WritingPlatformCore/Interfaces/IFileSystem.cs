

using System.Threading;
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64, CancellationToken cancellationToken);
        Task<bool> SaveTextFile(string fileTextName, string textBase64, CancellationToken cancellationToken);
        Task<bool> SaveAudioFile(string fileAudioName, string audioBase64, CancellationToken cancellationToken);

    }
}
