using System;

namespace DigitalWatch.States
{
    public class AnalogWatchState : State
    {
        public override void Show()
        {
          Analog.Show();
        }

        public override void Hide()
        {
            Analog.Hide();
        }

        public override void ShowNotification(string message, string from)
        {
            Analog.ShowNotification(message, from);
        }

        public override void UpdateTime(DateTime time)
        {
            Analog.UpdateTime(time);
        }
    }
}
