using System.Collections.Generic;
using System.Linq;

namespace DigitalWatch.Email
{
    public class Iterator : IAbstractIterator
    {
        private readonly List<Email> _collection;
        private int _current = 0;
        private int _step = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection"> the collection which holds the emails</param>

        public Iterator(List<Email> collection)
        {
            this._collection = collection;
        }

        /// <summary>
        /// Gets first item
        /// </summary>
        /// <returns>the first item in the collection</returns>
        public Email First()
        {
            _current = 0;
            return _collection[_current];
        }

        /// <summary>
        ///  Gets next item
        /// </summary>
        /// <returns>The next item</returns>
        public Email Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current];
            else
                return null;
        }

        /// <summary>
        ///  Gets or sets stepsize
        /// </summary>
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        /// <summary>
        ///  Gets current iterator item
        /// </summary>
        public Email CurrentItem
        {
            get { return _collection[_current]; }
        }

        /// <summary>
        ///  Gets whether iteration is complete
        /// </summary>
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }

        /// <summary>
        /// Gets the total items in the collection.
        /// </summary>
        public int Count
        {
            get { return _collection.Count; }
        }

        /// <summary>
        /// Gets the last item in the collection
        /// </summary>
        /// <returns>The last email in the collection</returns>
        public Email Last()
        {
            return _collection.Last();
        }
    }
}
