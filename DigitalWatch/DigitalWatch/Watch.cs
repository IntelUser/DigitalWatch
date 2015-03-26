using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalWatch.Email;
using DigitalWatch.States;

namespace DigitalWatch
{
    class Watch
    {
        private readonly EmailConnector _emailConnector;
        private Context _context;

        public Watch()
        {
            _context = new Context {State = new AnalogWatchState()};
            _context.State.Analog(_context);
        }

        public static void ShowEmailNotification(string message)
        {

        }
    }
}
