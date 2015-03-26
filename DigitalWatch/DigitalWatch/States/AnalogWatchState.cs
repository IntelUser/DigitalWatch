using clock;

namespace DigitalWatch.States
{
    public class AnalogWatchState : AbstractState
    {
        private readonly Window1 _window = new Window1();

        public override void Digital(Context context)
        {
            //context.State = new DigitalWatchState();
            _window.Hide();
        }

        public override void Analog(Context context)
        {
            context.State = new AnalogWatchState();
            _window.Show();
            
        }

        public override void Calculator(Context context)
        {
            //context.State = new CalculatorWatchState();
            _window.Hide();
        }

        
    }
/*
    public class DigitalWatchState : AbstractState
    {
        public override void Digital(Context context)
        {
            context.State = new DigitalWatchState();
        }

        public override void Analog(Context context)
        {
            context.State = new AnalogWatchState();
        }

        public override void Calculator(Context context)
        {
            context.State = new CalculatorWatchState();
        }
    }

    public class CalculatorWatchState : AbstractState
    {
        public override void Digital(Context context)
        {
            context.State = new DigitalWatchState();
        }

        public override void Analog(Context context)
        {
            context.State = new AnalogWatchState();
        }

        public override void Calculator(Context context)
        {
            context.State = new CalculatorWatchState();
        }
    }
 */
}
