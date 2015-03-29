﻿namespace DigitalWatch.States
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

        public override void ShowNotification(string message)
        {
            //todo
        }
    }
}
