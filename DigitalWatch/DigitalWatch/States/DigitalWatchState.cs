using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.States
{
    class DigitalWatchState : State
    {
        public override void Show()
        {
 	        Digital.Show();
        }

        public override void Hide()
        {
            Digital.Hide();
        }

        public override void ShowNotification(string message)
        {
            Digital.ShowNotification(message);
        }

        public override void UpdateTime(DateTime time)
        {
            Digital.UpdateTime(time);
        }
    }
}
