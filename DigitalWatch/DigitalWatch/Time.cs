using System;

namespace DigitalWatch
{
    /// <summary>
    /// Time class is implemented as Singleton pattern. 
    /// Use: Time.TimeManager.GetTime to get the current system time.
    /// </summary>
    public sealed class Time
    {
        // private constructor
        private Time() { }
        private static readonly Time _time = new Time();

        /// <summary>
        /// Returns the time object.
        /// </summary>
        public static Time TimeManager { get { return _time; } }

        /// <summary>
        /// Return the current system time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            return DateTime.Now;
        }

    }
}
