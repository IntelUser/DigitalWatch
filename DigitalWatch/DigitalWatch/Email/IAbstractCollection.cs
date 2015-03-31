using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.Email
{
    /// <summary>
    /// Interface for the Iterator pattern collection.
    /// </summary>
    interface IAbstractCollection
    {
        /// <summary>
        /// Gets the iterator for the collection
        /// </summary>
        /// <returns>the iterator</returns>
        Iterator CreateIterator();
    }
}
