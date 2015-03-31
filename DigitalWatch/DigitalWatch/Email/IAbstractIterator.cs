using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.Email
{
    /// <summary>
    /// Interface for the iterator
    /// </summary>
    interface IAbstractIterator
    {
        /// <summary>
        /// Gets the first Email in the collection.
        /// </summary>
        /// <returns>The first email object in the collection</returns>
        Email First();

        /// <summary>
        /// Returns the next email object
        /// </summary>
        /// <returns>the next email object</returns>
        Email Next();

        /// <summary>
        /// Return true if the collection has reached the last item.
        /// </summary>
        bool IsDone { get; }

        /// <summary>
        /// Gets the current item in the iteration.
        /// </summary>
        Email CurrentItem { get; }

        /// <summary>
        /// Returns the number of items in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns the last email in the collection
        /// </summary>
        /// <returns>the last email</returns>
        Email Last();
    }
}
