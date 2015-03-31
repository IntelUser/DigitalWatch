using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DigitalWatch.Email
{
    class EmailCollection : IAbstractCollection
    {
        private readonly List<Email> _emails;

        public EmailCollection()
        {
            _emails = new List<Email>();
        }
        public Iterator CreateIterator()
        {
            return new Iterator(this._emails);
        }

        // Gets item count
        public int Count
        {
            get { return _emails.Count; }
        }

        // Indexer
        public Email this[int index]
        {
            get { return _emails[index]; }
            set { _emails.Add(value); }
        }
    }

   
    
}
