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
        private static readonly Context Context = new Context();
        private static readonly Queue<State> States = new Queue<State>();
       

        public static void Start()
        {
            States.Enqueue(new AnalogWatchState());
            States.Enqueue(new CalculatorWatchState());
            States.Enqueue(new DigitalWatchState());

           SwitchState();
        }

        public static void ShowEmailNotification(string message)
        {

        }

        public static void SwitchState()
        {
            if (Context.State != null)
            {
               Context.State.Hide();
            }
            var tempState = States.Dequeue();       // remove state from stack
            Context.State = tempState;
            States.Enqueue(tempState);              // re-add state to stack
            Context.State.Show();
        }
    }
}
