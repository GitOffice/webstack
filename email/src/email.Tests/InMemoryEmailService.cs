using System.Collections.Generic;
using System.Linq;
using email.Providers;

namespace email.Tests
{
    public class InMemoryEmailService : IEmailProvider 
    {
        public ICollection<EmailMessage> Messages { get; private set; }

        public InMemoryEmailService()
        {
            Messages = new List<EmailMessage>();
        }

        public bool Send(EmailMessage message)
        {
            lock(Messages)
            {
                Messages.Add(message);
                return true;
            }
        }

        public bool[] Send(IEnumerable<EmailMessage> messages)
        {
            return messages.Select(Send).ToArray();
        }
    }
}
