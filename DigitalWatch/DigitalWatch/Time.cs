using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch
{
    public sealed class Time
    {
        // private constructor
        private Time() { }
        private static readonly Time _time = new Time();
        public static Time TimeManager { get { return _time; } }


        public DateTime GetTime()
        {
            return DateTime.Now;
        }

    }
}
