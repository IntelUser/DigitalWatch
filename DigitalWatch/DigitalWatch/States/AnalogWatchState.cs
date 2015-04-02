using System;

namespace DigitalWatch.States
{
    public class AnalogWatchState : State
    {
        /// <summary>
        /// Calls the Show method of the AnalogFace Window
        /// </summary>
        public override void Show()
        {
          Analog.Show();
        }

        /// <summary>
        /// Calls the Hide method of the AnalogFace Window
        /// </summary>
        public override void Hide()
        {
            Analog.Hide();
        }

        /// <summary>
        /// Shows the notification on the Analog Watch Face 
        /// by passing it to the ShowNotification method in AnalogFace.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="from">sender</param>
        public override void ShowNotification(string message, string from)
        {
            Analog.ShowNotification(message, from);
        }

        /// <summary>
        /// Passes the time to the AnalogFace Window.
        /// </summary>
        /// <param name="time"></param>
        public override void UpdateTime(DateTime time)
        {
            Analog.UpdateTime(time);
        }
    }
}
