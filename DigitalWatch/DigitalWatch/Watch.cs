using System.Collections.Generic;
using System.Timers;
using DigitalWatch.Email;
using DigitalWatch.States;

namespace DigitalWatch
{
    /// <summary>
    /// The main watch class. This class maintains the states, the timers for the clock and email generation.
    ///  also this class provides the function to switch between different states.
    /// </summary>
    public static class Watch
    {
        private static readonly Context Context = new Context();                    // Context which holds the current active state
        private static readonly Queue<State> States = new Queue<State>();
        private static Timer _timer, _emailCheckTimer;                              // timer fields for email function and time update function
        private static int _numberOfEmails = 0;
        private static readonly object Locker = new object();
       
        /// <summary>
        /// This method starts the timers to display time, adds the states to the waiting queue and activates the first state.
        /// </summary>
        public static void Start()
        {
            EmailConnector.GenerateEmails(1500);
            States.Enqueue(new AnalogWatchState());
            States.Enqueue(new CalculatorWatchState());
            States.Enqueue(new DigitalWatchState());

            SwitchState();
            _timer = new Timer(1000);
            _emailCheckTimer = new Timer(10000);

            _timer.Elapsed += _timer_Elapsed;
            _emailCheckTimer.Elapsed += _emailCheckTimer_Elapsed;
            _timer.Enabled = true;
            _emailCheckTimer.Enabled = true;
            
        }

        /// <summary>
        /// Runs every 10 seconds to check for new emails. Only used by timers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void _emailCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // gets the iterator
            var iterator = EmailConnector.GetEmails();
           
            // the collection is first checked if any items are present
            if (iterator.Count > _numberOfEmails)
            {
                lock (Locker)
                {
                    _numberOfEmails++;
                }
                ShowEmailNotification(iterator.Last().Message, iterator.Last().FromContact);
            }
        }

        /// <summary>
        /// Stops all timers.
        /// </summary>
        public static void Stop()
        {
            _timer.Enabled = false;
            _emailCheckTimer.Enabled = false;

        }

        /// <summary>
        /// Runs every second to call updatetime for the current active state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Context.State.UpdateTime(Time.TimeManager.GetTime());
        }

        /// <summary>
        /// Shows a notification message on the current active state window
        /// </summary>
        /// <param name="message">The message that you want to display</param>
        public static void ShowEmailNotification(string message, string from)
        {
            Context.State.ShowNotification(message, from);
        }

        /// <summary>
        /// Used to switch to different States and by doing so also changes the Window.
        /// </summary>
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
