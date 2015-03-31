using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (State != null)
            {
                State.Hide();
            }
        }
    }
}
