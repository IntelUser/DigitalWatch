using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.Email
{
    interface IAbstractIterator
    {
        Email First();
        Email Next();
        bool IsDone { get; }
        Email CurrentItem { get; }
        int Count { get; }
        Email Last();
    }
}
