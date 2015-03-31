using System;

namespace DigitalWatch.States
{
    /// <summary>
    /// State for the Digital Watch Face
    /// </summary>
    class DigitalWatchState : State
    {
        /// <summary>
        /// Calls the Show method of the DigitalFace Window
        /// </summary>
        public override void Show()
        {
 	        Digital.Show();
        }

        /// <summary>
        /// Calls the Hide method of the DigitalFace Window
        /// </summary>
        public override void Hide()
        {
            Digital.Hide();
        }

        /// <summary>
        /// Shows the notification on the Digital Watch Face 
        /// by passing it to the ShowNotification method in DigitalFace.
        /// </summary>
        /// <param name="message"></param>
        public override void ShowNotification(string message, string from)
        {
            Digital.ShowNotification(message, from);
        }

        /// <summary>
        /// Passes the time to the DigitalFace Window.
        /// </summary>
        /// <param name="time"></param>
        public override void UpdateTime(DateTime time)
        {
            Digital.UpdateTime(time);
        }
    }
}
