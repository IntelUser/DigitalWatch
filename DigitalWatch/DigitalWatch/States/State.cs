using System.Windows;
using clock;

namespace DigitalWatch.States
{
    public abstract class State
    {
        protected Window Calculator, Analog, Digital;

        protected State()
        {
            Calculator = new CalcFace();
            Analog = new AnalogFace();
        }

        public virtual void Show()
        {
           
        }

        public virtual void Hide()
        {
            
        }

       
    }
}
