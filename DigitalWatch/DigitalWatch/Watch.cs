using System.Collections.Generic;
using System.Timers;
using DigitalWatch.States;

namespace DigitalWatch
{
    public static class Watch
    {
        //private readonly EmailConnector _emailConnector;
        private static readonly Context Context = new Context();
        private static readonly Queue<State> States = new Queue<State>();
        private static Timer _timer;
       

        public static void Start()
        {
            States.Enqueue(new AnalogWatchState());
            States.Enqueue(new CalculatorWatchState());
            States.Enqueue(new DigitalWatchState());

           SwitchState();
           _timer = new Timer(1000);
           _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }


        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Context.State.UpdateTime(Time.TimeManager.GetTime());
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
