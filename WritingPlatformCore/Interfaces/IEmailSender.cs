
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
