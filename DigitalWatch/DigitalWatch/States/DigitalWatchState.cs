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
    }
}
