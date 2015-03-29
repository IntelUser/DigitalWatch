using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWatch.States
{
    class CalculatorWatchState : State
    {
        public override void Show()
        {
            Calculator.Show();
        }

        public override void Hide()
        {
            Calculator.Hide();
        }

        public override void ShowNotification(string message)
        {
            Calculator.ShowNotification(message);
        }

        public override void UpdateTime(DateTime time)
        {
           Calculator.UpdateTime(time);
        }
    }
}
