

using Email.Interfaces;
using System.Threading.Tasks;

namespace Email.Implemintation
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string address, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
