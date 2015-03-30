using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using DigitalWatch.Email;
using DigitalWatch.States;

namespace DigitalWatch
{
    public static class Watch
    {
        //private readonly EmailConnector _emailConnector;
        private static readonly Context Context = new Context();
        private static readonly Queue<State> States = new Queue<State>();
        private static Timer _timer, _emailCheckTimer;
        
        private static int numberOfEmails = 0;
        private static object locker;
       

        public static void Start()
        {
            States.Enqueue(new AnalogWatchState());
            States.Enqueue(new CalculatorWatchState());
            States.Enqueue(new DigitalWatchState());

            SwitchState();
            _timer = new Timer(1000);
            _emailCheckTimer = new Timer(1000);

            _timer.Elapsed += _timer_Elapsed;
            _emailCheckTimer.Elapsed += _emailCheckTimer_Elapsed;
            _timer.Enabled = true;
            _emailCheckTimer.Enabled = true;

            
            EmailConnector.GenerateEmails(15000);
            
        }

        static void _emailCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            if (EmailConnector.GetEmails().GetEnumerator() != null)
            {
                var emailCollection = EmailConnector.GetEmails().ToList();
                if (emailCollection.Count > numberOfEmails)
                {
                    lock (locker)
                    {
                        numberOfEmails = emailCollection.Count;
                    }

                    ShowEmailNotification(EmailConnector.GetEmails().First().Message);
                }
            }
            
           
            
           


           
        }

        public static void Stop()
        {
            _timer.Enabled = false;

        }


        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Context.State.UpdateTime(Time.TimeManager.GetTime());
        }

        public static void ShowEmailNotification(string message)
        {
            Context.State.ShowNotification(message);
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
