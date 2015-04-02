using System;

namespace DigitalWatch.States
{
    class CalculatorWatchState : State
    {
        /// <summary>
        /// Calls the Show method of the Calculator Window
        /// </summary>
        public override void Show()
        {
            Calculator.Show();
        }

        /// <summary>
        /// Calls the Hide method of the Calculator Window
        /// </summary>
        public override void Hide()
        {
            Calculator.Hide();
        }

        /// <summary>
        /// Shows the notification on the Digital Watch Face 
        /// by passing it to the ShowNotification method in CalculatorFace.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="from"> the sender</param>
        public override void ShowNotification(string message, string from)
        {
            Calculator.ShowNotification(message, from);
        }

        /// <summary>
        /// Passes the time to the CalculatorFace Window.
        /// </summary>
        /// <param name="time"></param>
        public override void UpdateTime(DateTime time)
        {
           Calculator.UpdateTime(time);
        }
    }
}
