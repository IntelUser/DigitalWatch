using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DigitalWatch.Email
{
    /// <summary>
    /// This class holds a list which consist of email objects 
    /// </summary>
    class EmailCollection : IAbstractCollection
    {
        private readonly List<Email> _emails;

        public EmailCollection()
        {
            _emails = new List<Email>();
        }

        /// <summary>
        /// Gets the iterator which can be used to loop 
        /// over the recieved emails.
        /// </summary>
        /// <returns>The iterator</returns>
        public Iterator CreateIterator()
        {
            return new Iterator(this._emails);
        }

        /// <summary>
        ///  Gets item count
        /// </summary>

        public int Count
        {
            get { return _emails.Count; }
        }

        /// <summary>
        ///  Indexer for adding email objects to the collection.
        ///  Adding works just like adding items to a Array object.
        /// [index].<Email>
        /// </summary>
        /// <param name="index">index number</param>
        /// <returns>Email object</returns>

        public Email this[int index]
        {
            get { return _emails[index]; }
            set { _emails.Add(value); }
        }
    }

   
    
}
