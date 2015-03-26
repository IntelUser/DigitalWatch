using System.Collections.Generic;

namespace DigitalWatch.Email
{
    public class EmailConnector
    {
        private readonly EmailCollection _emailCollection = new EmailCollection();

        public EmailConnector(EmailConnector emailConnector)
        {

        }

        public IEnumerable<Email> GetEmails()
        {
            return _emailCollection.GetEnumerator() as IEnumerable<Email>;
        }
    }
}
