using System;
using System.Windows;
using DigitalWatch.Windows;
using DigitalFace = DigitalWatch.Windows.DigitalFace;

namespace DigitalWatch.States
{
    public abstract class State
    {
        protected IFace Calculator, Analog, Digital;

        protected State()
        {
            Calculator = new CalcFace();
            Analog = new AnalogFace();
            Digital = new DigitalFace();
        }

        public virtual void Show()
        {
           
        }

        public virtual void Hide()
        {
            
        }

        public virtual void UpdateTime(DateTime time)
        {
            
        }

        public virtual void ShowNotification(String message)
        {
            
        }

       
    }
}
