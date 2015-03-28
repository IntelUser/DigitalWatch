using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalWatch.Email;
using DigitalWatch.States;

namespace DigitalWatch
{
    public static class Watch
    {
        //private readonly EmailConnector _emailConnector;
        private static Context _context;
        private static readonly State[] States = new State[]{new AnalogWatchState(), new CalculatorWatchState()};
       

        public static void Start()
        {
            _context = new Context {State = States[0]};
            
            _context.State.Show();
            
            
            

        }

        public static void ShowEmailNotification(string message)
        {

        }

        public static void SwitchState()
        {
            foreach (var state in States.Where(state => state != _context.State))
            {
                _context.State.Hide();
                _context.State = state;
                _context.State.Show();
                break;
            }
        }
    }
}
