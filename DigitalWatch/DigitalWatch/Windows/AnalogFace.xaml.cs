using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DigitalWatch.Windows
{
    public partial class AnalogFace : IFace
    {

        public AnalogFace()
        {
            InitializeComponent();
         
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove(); 
        }

        public void ShowNotification(string message, string from)
        {

            Task.Factory.StartNew(new Action(() =>

            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = false
                    };
                    

                    NotifyEllipse.Visibility = Visibility.Visible;
                    MessageBlock.Visibility = Visibility.Visible;
                    MessageBlock.Text = String.Format("From: {0}, Message: {1}", from, message);

                    var notifyGeometry = new RectangleGeometry {Rect = new Rect(0, 0, 300, 100)};
                    NotifyEllipse.Clip = notifyGeometry;
                    NotifyEllipse.BeginAnimation(OpacityProperty, fadeIn);
                    MessageBlock.BeginAnimation(OpacityProperty, fadeIn);
                }));


                    Thread.Sleep(4000);
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var fadeOut = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = false
                    };
                    NotifyEllipse.BeginAnimation(OpacityProperty, fadeOut);
                    MessageBlock.BeginAnimation(OpacityProperty, fadeOut);
                }));
            }));   
        }

        private void Next_window_button_OnClick(object sender, RoutedEventArgs e)
        {
             Watch.SwitchState();
        }

        public void UpdateTime(DateTime time)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                DateLabel.Content = String.Format("{0:dddd, MMMM d, yyyy}", time);
                secondHand.Angle = time.Second * 6;
                minuteHand.Angle = time.Minute * 6;
                hourHand.Angle = (time.Hour * 30) + (time.Minute * 0.5);
            }));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                Watch.SwitchState();
            }
        }
    }
}
