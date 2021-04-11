

using Email.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Email.Implemintation
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string address, string subject, string body)
        {
            Debug.WriteLine($"Email to {address} subject '{subject}' body '{body}'");
            return Task.CompletedTask;
        }
    }
}
