using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.Email
{
    public class Iterator : IAbstractIterator
    {
        private readonly List<Email> _collection;
        private int _current = 0;
        private int _step = 1;

        // Constructor
        public Iterator(List<Email> collection)
        {
            this._collection = collection;
        }

        // Gets first item
        public Email First()
        {
            _current = 0;
            return _collection[_current];
        }

        // Gets next item
        public Email Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current];
            else
                return null;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public Email CurrentItem
        {
            get { return _collection[_current]; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }


        public int Count
        {
            get { return _collection.Count; }
        }




        public Email Last()
        {
            return _collection.Last();
        }
    }
}
