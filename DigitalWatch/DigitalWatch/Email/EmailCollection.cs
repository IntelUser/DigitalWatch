using System.Collections;
using System.Collections.Generic;

namespace DigitalWatch.Email
{
    class EmailCollection : IEnumerable
    {
        private readonly List<Email> _emails = new List<Email>();

        public IEnumerator GetEnumerator()
        {
            return _emails.GetEnumerator();
        }

        public void AddEmail(Email email)
        {
            _emails.Add(email);
        }

        public void AddEmail(IEnumerable<Email> emailCollection)
        {
            foreach (var email in emailCollection)
            {
                _emails.Add(email);
            }
        }
    }
}
