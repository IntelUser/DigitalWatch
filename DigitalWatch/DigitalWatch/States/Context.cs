using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigitalWatch.States
{
    public class Context
    {
        public State State { get; set; }

        public void Show()
        {
            if (State != null)
            {
                State.Show();
            }
        }

        public void Hide()
        {
            
        }
    }
}
