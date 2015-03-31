using System;
using System.Windows;
using DigitalWatch.Windows;
using DigitalFace = DigitalWatch.Windows.DigitalFace;

namespace DigitalWatch.States
{
    /// <summary>
    /// Abstract State Class that can be inherited for multiple watchFaces.
    /// </summary>
    public abstract class State
    {
        protected IFace Calculator, Analog, Digital;

        protected State()
        {
            Calculator = new CalcFace();
            Analog = new AnalogFace();
            Digital = new DigitalFace();
        }

        /// <summary>
        /// Implement this method for showing a window.
        /// </summary>
        public virtual void Show()
        {
           
        }

        /// <summary>
        /// Implement this method for hiding a window.
        /// </summary>
        public virtual void Hide()
        {
            
        }

        /// <summary>
        /// Implement this method for Updating the time.
        /// </summary>
        /// <param name="time">The current datetime</param>
        public virtual void UpdateTime(DateTime time)
        {
            
        }

        /// <summary>
        /// Implement this method for showing notifications.
        /// </summary>
        /// <param name="message"></param>
        public virtual void ShowNotification(String message)
        {
            
        }

       
    }
}
